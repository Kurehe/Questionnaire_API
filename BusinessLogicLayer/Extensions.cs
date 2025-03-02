using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Extensions
    {
        public static void Add_BLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuestionService, QuestionService>();
        }
    }
}
