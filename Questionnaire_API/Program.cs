using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.AppContext;

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

            services.Add_DAL(config);   // ���������� ������ ������ � �������
            services.Add_BLL();         // ���������� ������ ������ ������

            services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseHsts();

                // ��������� ������� ��� ������� � ������ ����������
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // ���������� �� � ��������� ����� ����� ����������������� � API
            using (var scope = app.Services.CreateScope())
            {
                SeedData.InitializeDataBaseState(scope.ServiceProvider, app.Configuration);
            }

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
