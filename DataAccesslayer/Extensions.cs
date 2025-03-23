using DataAccessLayer.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class Extensions
    {
        public static void Add_DAL(this IServiceCollection services, IConfiguration configuration)
        {
            string hostdb = configuration.GetSection("POSTGRES_DB_HOST").Value ?? "localhost";
            string portdb = configuration.GetSection("POSTGRES_DB_PORT").Value ?? "5432";
            string? namedb = configuration.GetSection("POSTGRES_DB").Value;

            string usernamedb = configuration.GetSection("POSTGRES_USER").Value ?? "postgres";
            string? passworddb = configuration.GetSection("POSTGRES_PASSWORD").Value;

            services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql($"Host={hostdb};Port={portdb};Database={namedb};Username={usernamedb};Password={passworddb}")
                    //.LogTo(Console.WriteLine)
                    ;
            });

            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        }
    }
}
