namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Вариант ответа на вопрос анкеты
    /// </summary>
    public class Answer
    {
        public int Id { get; set; }
        /// <summary>
        /// Один из вариантов ответа (не может принимать null)
        /// </summary>
        public string VariantAnswer { get; set; }


        public int QuestionId { get; set; }
        /// <summary>
        /// Вопрос к которому относиться ответ
        /// </summary>
        public Question Question { get; set; }

        
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
