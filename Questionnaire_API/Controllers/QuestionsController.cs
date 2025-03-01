using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Index()
        {
            logger.Log(LogLevel.Information, "get index !");
            return Ok("Hello world!");
        }
    }
}
