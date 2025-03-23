using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IQuestionsRepository
    {
        /// <summary>
        /// Получить информацию о респонденте
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<Interview?> GetInterviewByGuid(Guid guid);
        /// <summary>
        /// Получить информацию о вопросе по его Id
        /// </summary>
        /// <param name="questionId">Id вопроса</param>
        /// <returns></returns>
        Task<Question?> GetQuestionById(int questionId);
        /// <summary>
        /// Добавить ответ респондента в БД
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="questionID"></param>
        /// <param name="answerId"></param>
        /// <returns></returns>
        Task AddAnswerRespondent(Guid guid, int questionID, int answerId);
        /// <summary>
        /// Получить вопросы анкеты, которую проходит респондент
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<List<Question>> GetQuestionsInterviewByGuid(Guid guid);
        /// <summary>
        /// Задать флаг, что респондент прошел опрос
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task InterviewSurveyComplete(Guid guid);
    }
}
