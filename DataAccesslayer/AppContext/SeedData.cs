using DataAccesslayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccesslayer.AppContext
{
    public class SeedData
    {
        /// <summary>
        /// Инициализация БД - приведение её к моменту когда можно взаимодействовать с АПИ
        /// </summary>
        /// <param name="provider"></param>
        public static void InitializeDataBaseState(IServiceProvider provider)
        {
            using (var context = new DataContext(provider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (!context.Surveys.Any())
                {
                    var survery = new Survey
                    {
                        Title = "Опросник 1",
                        SurveyDescription = "Какое-то описание",
                        Questions = new List<Question>()
                    };

                    // Вопросы к анкете
                    var Quest1 = new Question
                    {
                        TextQuestion = "В каком регионе Вы живете?",    // Вопрос
                        Answer = new List<Answer>()                     // Возможные ответы
                        {
                            new Answer { VariantAnswer = "Москва"},
                            new Answer { VariantAnswer = "Московская область"},
                            new Answer { VariantAnswer = "Санкт-Петербург"},
                            new Answer { VariantAnswer = "Ленинградская область"},
                            new Answer { VariantAnswer = "Белгородская область"}
                        },
                        Survey = survery
                    };
                    var Quest2 = new Question
                    {
                        TextQuestion = "В каком городе Вы проживаете?",
                        Answer = new List<Answer>()
                        {
                            new Answer {VariantAnswer = "Москва"},
                            new Answer {VariantAnswer = "Калуга"},
                            new Answer {VariantAnswer = "Тула"},
                            new Answer {VariantAnswer = "Рязань"},
                            new Answer {VariantAnswer = "Воронеж"}
                        },
                        Survey = survery
                    };
                    var Quest3 = new Question
                    {
                        TextQuestion = "Какая у вас на улице погода?",
                        Answer = new List<Answer>()
                        {
                            new Answer { VariantAnswer = "Лето" },
                            new Answer { VariantAnswer = "Зима" },
                            new Answer { VariantAnswer = "Зима (без снега)" },
                            new Answer { VariantAnswer = "Осень" },
                            new Answer { VariantAnswer = "Я в бункере живу" }
                        },
                        Survey = survery
                    };
                    var Quest4 = new Question
                    {
                        TextQuestion = "Как вам опрос?",
                        Answer = new List<Answer>()
                        {
                            new Answer { VariantAnswer = "Отличный" },
                            new Answer { VariantAnswer = "Хороший" },
                            new Answer { VariantAnswer = "Нормально" },
                            new Answer { VariantAnswer = "Слабо" },
                            new Answer { VariantAnswer = "Плохо" }
                        },
                        Survey = survery
                    };

                    survery.Questions.Add(Quest1);
                    survery.Questions.Add(Quest2);
                    survery.Questions.Add(Quest3);
                    survery.Questions.Add(Quest4);

                    context.Surveys.Add(survery);
                    context.SaveChanges();
                }

                if (!context.Interviews.Any())
                {
                    var survery = context.Surveys.Last(); // переделать!

                    var interview = new Interview   // добавление респондента, если его нет
                    {
                        Id = Guid.NewGuid(),
                        Surveys = survery,
                        StartSurveyTime = DateTime.UtcNow
                    };

                    context.Interviews.Add(interview);
                    context.SaveChanges();
                }
                else
                {
                    // если респондент есть, то проверить сколько он дал ответов на анкету
                    int countQuestion = context.Surveys.Last().Questions.Count();
                    int countQuestRespondent = context.Interviews.Last().Results.Count();

                    if (countQuestion <= countQuestRespondent) // Если респондент на всё ответил, то создать нового респондента
                    {
                        var interview = new Interview   // добавление респондента, если его нет
                        {
                            Id = Guid.NewGuid(),
                            Surveys = context.Surveys.Last(),
                            StartSurveyTime = DateTime.UtcNow
                        };
                        
                        context.Interviews.Add(interview);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
