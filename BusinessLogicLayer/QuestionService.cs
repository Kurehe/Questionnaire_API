using BusinessLogicLayer.Model;
using DataAccesslayer;
using Microsoft.Extensions.Logging;

namespace BusinessLogicLayer
{
    internal class QuestionService : IQuestionService
    {
        private readonly ILogger<QuestionService> logger;
        private readonly IQuestionsRepository questionsRepository;

        public QuestionService(ILogger<QuestionService> logger, IQuestionsRepository questions)
        {
            this.logger = logger;
            this.questionsRepository = questions;
        }


        public Task<DataQuestion> GetQuestionById(Guid guid, int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAnswerRespondent(Guid guid, int QuestionID, int AnswerId)
        {
            throw new NotImplementedException();
        }
        
        public Task<int?> NextIdQuestion(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
