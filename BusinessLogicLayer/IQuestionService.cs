using BusinessLogicLayer.Model;

namespace BusinessLogicLayer
{
    public interface IQuestionService
    {
        /// <summary>
        /// Получение информации о вопросе по Id и Guid респондента
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<DataQuestion> GetQuestionById(Guid guid, int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="QuestionID"></param>
        /// <param name="AnswerId"></param>
        /// <returns></returns>
        Task UpdateAnswerRespondent(Guid guid, int QuestionID, int AnswerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<int?> NextIdQuestion(Guid guid);
    }
}