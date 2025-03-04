using DataAccesslayer.AppContext;
using DataAccesslayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccesslayer
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

        public async Task<Question?> GetQuestionById(int QuestionId)
        {
            return await context.Questions
                .Include(x => x.Answer)
                .FirstOrDefaultAsync(x => x.Id == QuestionId);
        }

        public async Task<Interview?> GetInterviewByGuid(Guid Guid)
        {
            var interview = await context.Interviews
                .Include(x => x.Results)
                .FirstOrDefaultAsync(x => x.Id == Guid);
            return interview;
        }

        public async Task AddAnswerRespondent(Guid guid, int QuestionID, int AnswerId)
        {
            var interw = await GetInterviewByGuid(guid);
            var quest = await context.Questions.FirstOrDefaultAsync(x => x.Id == QuestionID);
            var answer = await context.Answers.FirstOrDefaultAsync(x => x.Id == AnswerId);

            if (interw == null) { return; }
            if (quest == null) { return; }
            if (answer == null) { return; }

            interw.Results.Add(new Result
            {
                Interview = interw,
                Question = quest,
                Answer = answer
            });

            await context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetQuestionsInterviewByGuid(Guid guid)
        {
            var interwRes = await context.Interviews
                .Include(x => x.Survey)
                .FirstOrDefaultAsync(x => x.Id == guid);

            var survey = await context.Surveys
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x == interwRes.Survey);

            return survey.Questions.ToList();
        }

        public async Task InterviewSurveyComplete(Guid guid)
        {
            var interw = await GetInterviewByGuid(guid);
            
            interw.IsSurveyCompleted = true;
            interw.EndSurveyTime = DateTime.UtcNow;

            context.Update(interw);
            await context.SaveChangesAsync();
        }
    }
}
