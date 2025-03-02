namespace Questionnaire_API.Model
{
    /// <summary>
    /// Объект запроса данных о новом вопросе
    /// </summary>
    public class GetQuestionRequest
    {
        /// <summary>
        /// Идентификатор респондента, который проходит опрос
        /// </summary>
        public Guid RespondentGuid { get; set; }
        
        /// <summary>
        /// Ид вопроса, данные которого запрашиваются
        /// </summary>
        public int IdQuestion { get; set; }        
    }
}
