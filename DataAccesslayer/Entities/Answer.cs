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

        /// <summary>
        /// К какому вопросу соответвует ответ
        /// </summary>
        //public Question Question { get; set; }
    }
}
