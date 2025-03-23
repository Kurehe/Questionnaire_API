using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class Extensions
    {
        public static void Add_BLL(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
        }
    }
}
