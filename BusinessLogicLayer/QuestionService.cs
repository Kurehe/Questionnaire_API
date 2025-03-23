using BusinessLogicLayer.Model;
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace BusinessLogicLayer
{
    internal class QuestionService : IQuestionService
    {
        private readonly ILogger<QuestionService> logger;
        private readonly IQuestionsRepository repository;

        public QuestionService(ILogger<QuestionService> logger, IQuestionsRepository questions)
        {
            this.logger = logger;
            repository = questions;
        }

        public async Task<DataQuestion?> GetQuestionById(int id)
        {
            var questionInfo = await repository.GetQuestionById(id);
            if (questionInfo != null)
            {
                DataQuestion question = new DataQuestion
                {
                    TextQuestion = questionInfo.TextQuestion,
                };

                foreach (var item in questionInfo.Answer)
                {
                    question.Answers.Add(item.Id, item.VariantAnswer);
                }
                return question;
            }
            return null;
        }

        public async Task UpdateAnswerRespondent(Guid guid, int questionID, int answerId)
        {
            var interview = await repository.GetInterviewByGuid(guid);

            // проверка на существование респондента с подобным guid
            if (interview == null) { return; }
            if (interview.IsSurveyCompleted) { return; } // проверка на то прошел ли респондент опрос

            var question = await repository.GetQuestionById(questionID);
            if (question == null) { return; }

            if (question.Answer.FirstOrDefault(x => x.Id == answerId) != null)
            {
                if (interview.Results.FirstOrDefault(x => x.QuestionId == questionID) == null)
                {
                    await repository.AddAnswerRespondent(guid, questionID, answerId);
                }
                else
                {
                    logger.Log(LogLevel.Warning, $"Респондент {guid} уже ответил на этот вопрос!");
                }
            }
        }

        public async Task<int> NextIdQuestion(Guid guid)
        {
            var interview = await repository.GetInterviewByGuid(guid);

            if (interview == null) { return 0; }
            if (interview.IsSurveyCompleted) { return 0; }

            // получить все ответы юзера
            //var resInterview = await repository.GetResultsInterviewByGuid(guid);

            // получить все вопросы по анкете (относительно респондента)
            var questions = await repository.GetQuestionsInterviewByGuid(guid);

            // сравнить ответы на вопросы и вопросы анкеты
            // т.е. если респондент ответил на все вопросы анкеты выставить для него флаг завершения опроса
            // а если нет выдать айди следующего вопроса

            IEnumerable<int> questionIds = questions.Select(x => x.Id);
            IEnumerable<int> resultQuestionsId = interview.Results.Select(x => x.QuestionId ?? 0);

            int res = questionIds.Except(resultQuestionsId).FirstOrDefault();
            if (res == 0)
            {
                await repository.InterviewSurveyComplete(guid);
            }

            return res;
        }
    }
}
