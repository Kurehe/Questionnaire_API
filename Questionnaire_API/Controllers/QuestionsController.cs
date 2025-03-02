using Microsoft.AspNetCore.Mvc;
using Questionnaire_API.Model;

namespace Questionnaire_API.Controllers
{
    [ApiController]
    [Route("Questions")]
    public class QuestionsController : Controller
    {
        private readonly ILogger<QuestionsController> logger;

        public QuestionsController(ILogger<QuestionsController> logger)
        {
            this.logger = logger;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    logger.Log(LogLevel.Information, "get index !");
        //    return Ok("Hello world!");
        //}

        /// <summary>
        /// Получение данных вопроса
        /// </summary>
        /// <param name="request">Guid пользователя и Id вопроса</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<QuestionResponse> GetDataQuestion([FromQuery]GetQuestionRequest request)
        {
            if (request.IdQuestion == 1)
            {
                logger.Log(LogLevel.Information, $"get data Question on id: {request.IdQuestion}");
            }

            var respose = new QuestionResponse {
                QuestionText = "new text!",
                Answers = new Dictionary<int, string>
                {
                    {1, "вариант 1" },
                    {2, "вариант 2" },
                    {3, "вариант 3" },
                    {4, "Вариант 4" }
                }
            };

            await Task.Delay(500);

            return respose;
        }

        [HttpPost]
        public async Task<int> SaveAnswerQuestion(SaveAnswerRequest request)
        {
            logger.Log(LogLevel.Information, $"Guid {request.RespondentGuid}, Id Question: {request.IdQuestion}, Id Answer: {request.IdAnswer}");

            await Task.Delay(500);

            int nextQuetId = 1;

            return nextQuetId;
        }
    }
}
