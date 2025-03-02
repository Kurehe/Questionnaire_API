using DataAccesslayer.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccesslayer
{
    public static class Extensions
    {
        public static void Add_DAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Questionnaire;Trusted_Connection=True;MultipleActiveResultSets=true");
                //x.UseNpgsql("Host=localhost;Database=Questionnaire;Username=AppCon;Password=123456");
            });

            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        }
    }
}
