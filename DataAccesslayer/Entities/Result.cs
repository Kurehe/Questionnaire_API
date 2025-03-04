namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Данные ответов людей на вопросы анкеты
    /// </summary>
    public class Result
    {
        public int Id { get; set; }

        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }


        public int? QuestionId { get; set; }
        public Question Question { get; set; }      // ссылка на вопрос (один к одному)


        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }          // ссылка на ответ от этого опроса (один к одному)
    }
}
