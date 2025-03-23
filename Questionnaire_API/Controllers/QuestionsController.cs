using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Questionnaire_API.Model;

namespace Questionnaire_API.Controllers
{
    [ApiController]
    [Route("Questions")]
    public class QuestionsController : ControllerBase
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
        public async Task<IActionResult> GetDataQuestion([FromRoute] int QuestionId)
        {
            var data = await questionService.GetQuestionById(QuestionId);

            if (data != null)
            {
                QuestionResponse response = new QuestionResponse
                {
                    QuestionText = data.TextQuestion,
                    Answers = data.Answers
                };

                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Сохранение результатов и возвращение Ид следующего вопроса
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Возвращаемый Ид может быть равен Null в случае если вопросы в анкете кончились</returns>
        [HttpPost]
        public async Task<IActionResult> SaveAnswerQuestion(Guid respondentGuid, int idQuestion, int idAnswer)
        {
            await questionService.UpdateAnswerRespondent(respondentGuid, idQuestion, idAnswer);
            int nextQuestionId = await questionService.NextIdQuestion(respondentGuid);

            if (nextQuestionId == 0)
            {
                return NoContent();
            }
            return Ok(nextQuestionId);
        }
    }
}
