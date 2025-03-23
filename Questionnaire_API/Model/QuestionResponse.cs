namespace Questionnaire_API.Model
{
    /// <summary>
    /// Ответ на запрос данных о вопросе
    /// </summary>
    public class QuestionResponse
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string? QuestionText { get; set; }
        
        /// <summary>
        /// Словарь ответов (Id ответа, строка ответа)
        /// </summary>
        public required Dictionary<int, string> Answers { get; set; }
    }
}
