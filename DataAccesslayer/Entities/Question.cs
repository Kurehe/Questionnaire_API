namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Вопрос анкеты
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Ид вопроса
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string TextQuestion { get; set; }
        /// <summary>
        /// Пояснение к вопросу (его может и не быть)
        /// </summary>
        public string? ExplanQuestion { get; set; }


        public int SurveyId { get; set; }
        /// <summary>
        /// То к какому опроснику (анкете) относиться вопрос
        /// </summary>
        public Survey Survey { get; set; } = null!;


        /// <summary>
        /// Варианты ответов на вопрос
        /// </summary>
        public ICollection<Answer> Answer { get; set; } = new List<Answer>();


        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
