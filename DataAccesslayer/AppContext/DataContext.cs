using DataAccesslayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccesslayer.AppContext
{
    internal class DataContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base()
        {
            Database.EnsureCreated();
        }
    }
}
