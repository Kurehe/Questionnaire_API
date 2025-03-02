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
        /// <param name="request">Guid пользователя и Id вопроса</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<QuestionResponse> GetDataQuestion([FromQuery]GetQuestionRequest request)
        {
            var data = await questionService.GetQuestionById(request.RespondentGuid, request.IdQuestion);

            QuestionResponse response = new QuestionResponse
            {
                QuestionText = data.TextQuestion,
                Answers = data.Answers
            };

            return response;
        }

        /// <summary>
        /// Сохранение результатов и возвращение Ид следующего вопроса
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Возвращаемый Ид может быть равен Null в случае если вопросы в анкете кончились</returns>
        [HttpPost]
        public async Task<int?> SaveAnswerQuestion(SaveAnswerRequest request)
        {
            await questionService.UpdateAnswerRespondent(request.RespondentGuid, request.IdQuestion, request.IdAnswer);
            int? nextQuetId = await questionService.NextIdQuestion(request.RespondentGuid);

            //logger.Log(LogLevel.Information, $"Guid {request.RespondentGuid}, Id Question: {request.IdQuestion}, Id Answer: {request.IdAnswer}");
            //await Task.Delay(500);
            //int nextQuetId = 1;

            return nextQuetId;
        }
    }
}
