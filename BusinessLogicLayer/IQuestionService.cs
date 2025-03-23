using BusinessLogicLayer.Model;

namespace BusinessLogicLayer
{
    public interface IQuestionService
    {
        /// <summary>
        /// Получение информации о вопросе по Id вопроса
        /// </summary>
        /// <param name="id">Id вопроса</param>
        /// <returns></returns>
        Task<DataQuestion?> GetQuestionById(int id);

        /// <summary>
        /// Обновление ответов респондента
        /// </summary>
        /// <param name="guid">уникальный идентификатор респондента</param>
        /// <param name="questionID">Айди вопроса</param>
        /// <param name="answerId">Айди ответа</param>
        /// <returns></returns>
        Task UpdateAnswerRespondent(Guid guid, int questionID, int answerId);

        /// <summary>
        /// Получить следующий вопрос по Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Если респондент ответил на все вопросы то вернется 0</returns>
        Task<int> NextIdQuestion(Guid guid);
    }
}