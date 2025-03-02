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
        /// Анкета которая проходиться респондентом
        /// </summary>
        public Survey Surveys { get; set; }

        /// <summary>
        /// Время начала опроса
        /// </summary>
        public DateTime StartSurveyTime { get; set; }

        /// <summary>
        /// Время окончания опроса (может быть равно null, т.к. респондент может не завершить опрос
        /// </summary>
        public DateTime? EndSurveyTime { get; set; }

        /// <summary>
        /// Ответы пользователя
        /// </summary>
        public ICollection<Result> Results { get; set; }
    }
}
