using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer
{
    internal class QuestionsRepository : IQuestionsRepository
    {
        private readonly ILogger<QuestionsRepository> logger;
        private readonly DataContext context;

        public QuestionsRepository(DataContext context, ILogger<QuestionsRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Question?> GetQuestionById(int questionId)
        {
            return await context.Questions
                .Include(x => x.Answer)
                .FirstOrDefaultAsync(x => x.Id == questionId);
        }

        public async Task<Interview?> GetInterviewByGuid(Guid guid)
        {
            var interview = await context.Interviews
                .Include(x => x.Results)
                .FirstOrDefaultAsync(x => x.Id == guid);
            return interview;
        }

        public async Task AddAnswerRespondent(Guid guid, int questionID, int answerId)
        {
            var interview = await GetInterviewByGuid(guid);
            var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == questionID);
            var answer = await context.Answers.FirstOrDefaultAsync(x => x.Id == answerId);

            if (interview == null || question == null || answer == null) { return; }

            interview.Results.Add(new Result
            {
                Interview = interview,
                Question = question,
                Answer = answer
            });

            await context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetQuestionsInterviewByGuid(Guid guid)
        {
            var interview = await context.Interviews
                .Include(x => x.Survey)
                .FirstOrDefaultAsync(x => x.Id == guid);

            var survey = await context.Surveys
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x == interview.Survey);

            return survey.Questions.ToList();
        }

        public async Task InterviewSurveyComplete(Guid guid)
        {
            var interview = await GetInterviewByGuid(guid);

            interview.IsSurveyCompleted = true;
            interview.EndSurveyTime = DateTime.UtcNow;

            context.Update(interview);
            await context.SaveChangesAsync();
        }
    }
}
