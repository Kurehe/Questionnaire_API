namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Данные ответов людей на вопросы анкеты
    /// </summary>
    public class Result
    {
        public int Id { get; set; }

        // ссылка на вопрос (один к одному)
        public Question QuestionId { get; set; }

        // ссылка на ответ от этого опроса (один к одному)
        public Answer AnswerId { get; set; }
    }
}
