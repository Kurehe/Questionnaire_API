namespace BusinessLogicLayer.Model
{
    public class DataQuestion
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string TextQuestion { get; set; }

        /// <summary>
        /// Словарь ответов (Id ответа, строка ответа)
        /// </summary>
        public Dictionary<int, string> Answers { get; set; } = new Dictionary<int, string>();
    }
}
