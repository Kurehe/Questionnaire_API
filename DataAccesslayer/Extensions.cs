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
            string? hostdb = configuration.GetSection("POSTGRES_DB_HOST").Value;
            string? portdb = configuration.GetSection("POSTGRES_DB_PORT").Value;
            string? namedb = configuration.GetSection("POSTGRES_DB_NAME").Value;

            string? usernamedb = configuration.GetSection("POSTGRES_USER").Value;
            string? passworddb = configuration.GetSection("POSTGRES_PASSWORD").Value;

            services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql($"Host={hostdb};Port={portdb};Database={namedb};Username={usernamedb};Password={passworddb}");
            });

            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        }
    }
}
