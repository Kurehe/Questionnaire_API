using BusinessLogicLayer.Model;
using DataAccesslayer;
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

        public async Task<DataQuestion?> GetQuestionById(int Id)
        {
            var QuestionInfo = await repository.GetQuestionById(Id);
            if (QuestionInfo != null)
            {
                DataQuestion question = new DataQuestion
                {
                    TextQuestion = QuestionInfo.TextQuestion,
                };

                foreach (var item in QuestionInfo.Answer)
                {
                    question.Answers.Add(item.Id, item.VariantAnswer);
                }
                return question;
            }
            return null;
        }

        public async Task UpdateAnswerRespondent(Guid guid, int QuestionID, int AnswerId)
        {
            var interview = await repository.GetInterviewByGuid(guid);

            // проверка на существование респондента с подобным guid
            if (interview == null) { return; }
            if (interview.IsSurveyCompleted) { return; } // проверка на то прошел ли респондент опрос

            var question = await repository.GetQuestionById(QuestionID);
            if (question == null) { return; }

            if (question.Answer.FirstOrDefault(x => x.Id == AnswerId) != null)
            {
                if (interview.Results.FirstOrDefault(x => x.QuestionId == QuestionID) == null)
                {
                    await repository.AddAnswerRespondent(guid, QuestionID, AnswerId);
                }
                else
                {
                    logger.Log(LogLevel.Warning, $"Респондент {guid} уже ответил на этот вопрос!");
                }
            }
        }

        public async Task<int?> NextIdQuestion(Guid guid)
        {
            var interview = await repository.GetInterviewByGuid(guid);

            if (interview == null) { return 0; }
            if (interview.IsSurveyCompleted) { return 0; }

            // получить все ответы юзера
            //var resInterview = await repository.GetResultsInterviewByGuid(guid);

            // получить все вопросы по анкете (относительно респондента)
            var qustions = await repository.GetQuestionsInterviewByGuid(guid);

            // сравнить ответы на вопросы и вопросы анкеты
            // т.е. если респондент ответил на все вопросы анкеты выставитьдля него флаг завершения опроса
            // а если нет выдать айди следующего вопроса

            IEnumerable<int> qustIds = qustions.Select(x => x.Id);
            IEnumerable<int> resQIds = interview.Results.Select(x => x.QuestionId ?? 0);

            int res = qustIds.Except(resQIds).FirstOrDefault();
            if (res == 0)
            {
                await repository.InterviewSurveyComplete(guid);
            }

            return res;
        }
    }
}
