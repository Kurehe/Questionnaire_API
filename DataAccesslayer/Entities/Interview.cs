namespace DataAccesslayer.Entities
{
    /// <summary>
    /// Информация об интервью (отдельной сессии прохождения анкеты конкретным человеком)
    /// </summary>
    public class Interview
    {
        /// <summary>
        /// Уникальный идентификатор респондента
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Время начала опроса
        /// </summary>
        public DateTime StartSurveyTime { get; set; }
        /// <summary>
        /// Время окончания опроса (может быть равно null, т.к. респондент может не завершить опрос
        /// </summary>
        public DateTime? EndSurveyTime { get; set; }
        /// <summary>
        /// Флаг завершения опроса (true - опрос завершен, false - опрос не завершен)
        /// </summary>
        public bool IsSurveyCompleted { get; set; } = false;


        public int SurveyId { get; set; }
        /// <summary>
        /// Анкета которая проходиться респондентом
        /// </summary>
        public Survey Survey { get; set; }

        /// <summary>
        /// Ответы респондента
        /// </summary>
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
