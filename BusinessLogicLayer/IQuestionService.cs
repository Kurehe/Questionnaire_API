using BusinessLogicLayer.Model;

namespace BusinessLogicLayer
{
    public interface IQuestionService
    {
        /// <summary>
        /// Получение информации о вопросе по Id вопроса
        /// </summary>
        /// <param name="Id">Id вопроса</param>
        /// <returns></returns>
        Task<DataQuestion?> GetQuestionById(int Id);

        /// <summary>
        /// Обновление ответов респондента
        /// </summary>
        /// <param name="guid">уникальный идентификатор респондента</param>
        /// <param name="QuestionID">Айди вопроса</param>
        /// <param name="AnswerId">Айди ответа</param>
        /// <returns></returns>
        Task UpdateAnswerRespondent(Guid guid, int QuestionID, int AnswerId);

        /// <summary>
        /// Получить следующий вопрос по Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Если респондент ответил на все вопросы то вернется 0</returns>
        Task<int> NextIdQuestion(Guid guid);
    }
}