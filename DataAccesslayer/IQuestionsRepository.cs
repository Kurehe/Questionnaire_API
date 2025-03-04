using DataAccesslayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer
{
    public interface IQuestionsRepository
    {
        /// <summary>
        /// Получить информацию о респонденте
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        Task<Interview?> GetInterviewByGuid(Guid Guid);
        /// <summary>
        /// Получить информацию о вопросе по его Id
        /// </summary>
        /// <param name="QuestionId">Id вопроса</param>
        /// <returns></returns>
        Task<Question?> GetQuestionById(int QuestionId);
        /// <summary>
        /// Добавить ответ респондента в БД
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="QuestionID"></param>
        /// <param name="AnswerId"></param>
        /// <returns></returns>
        Task AddAnswerRespondent(Guid guid, int QuestionID, int AnswerId);
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
