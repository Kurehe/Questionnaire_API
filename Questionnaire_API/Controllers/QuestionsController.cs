using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Questionnaire_API.Model;

namespace Questionnaire_API.Controllers
{
    [ApiController]
    [Route("Questions")]
    public class QuestionsController : Controller
    {
        private readonly ILogger<QuestionsController> logger;
        private readonly IQuestionService questionService;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionService question)
        {
            this.logger = logger;
            questionService = question;
        }

        /// <summary>
        /// Получение данных вопроса
        /// </summary>
        /// <param name="QuestionId">Id вопроса</param>
        /// <returns>Возвращает вопрос и варианты ответа на него</returns>
        [HttpGet("{QuestionId:int}")]
        public async Task<QuestionResponse?> GetDataQuestion([FromRoute] int QuestionId)
        {
            var data = await questionService.GetQuestionById(QuestionId);

            if (data != null)
            {
                QuestionResponse response = new QuestionResponse
                {
                    QuestionText = data.TextQuestion,
                    Answers = data.Answers
                };

                return response;
            }
            return null;
        }

        /// <summary>
        /// Сохранение результатов и возвращение Ид следующего вопроса
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Возвращаемый Ид может быть равен Null в случае если вопросы в анкете кончились</returns>
        [HttpPost]
        public async Task<int?> SaveAnswerQuestion(Guid RespondentGuid, int IdQuestion, int IdAnswer)
        {
            await questionService.UpdateAnswerRespondent(RespondentGuid, IdQuestion, IdAnswer);
            int? nextQuetId = await questionService.NextIdQuestion(RespondentGuid);

            return nextQuetId;
        }
    }
}
