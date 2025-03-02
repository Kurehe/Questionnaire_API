namespace Questionnaire_API.Model
{
    public class SaveAnswerRequest
    {
        /// <summary>
        /// Идентификатор респондента, который ответил на вопрос
        /// </summary>
        public Guid RespondentGuid { get; set; }

        /// <summary>
        /// Ид вопроса на который ответил респондент
        /// </summary>
        public int IdQuestion {  get; set; }

        /// <summary>
        /// Ид ответа на вопрос, на который ответил респондент
        /// </summary>
        public int IdAnswer { get; set; }
    }
}
