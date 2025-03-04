namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Информация об анкете
    /// </summary>
    public class Survey
    {
        public int Id { get; set; }

        /// <summary>
        /// Название анкеты
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание анкеты
        /// </summary>
        public string SurveyDescription { get; set; }


        /// <summary>
        /// Вопросы анкеты
        /// </summary>
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        
        /// <summary>
        /// Респонденты проходящие анкету
        /// </summary>
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    }
}
