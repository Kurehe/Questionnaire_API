
using BusinessLogicLayer;
using DataAccesslayer;
using DataAccesslayer.AppContext;

namespace Questionnaire_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            var services = builder.Services;

            // Add services to the container.
            services.AddControllers();

            services.Add_DAL(config);
            services.Add_BLL(config);

            services.AddSwaggerGen();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseHsts();

                // Включение свагера для отладки в режиме разработки
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            // ToDo написать логику приведения БД к конечному состоянию, после которого можно взаимодействовать с АПИ
            using (var scope = app.Services.CreateScope())
            {
                SeedData.InitializeDataBaseState(scope.ServiceProvider);
            }


                app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
