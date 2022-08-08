using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Abstract;
using Model.Concrete;
namespace Data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(Connection.connectionString);
            }
        }
        public DbSet<SubjectEntities> Subjects { get; set; }
        public DbSet<AnswerEntities> Answers { get; set; }
       

    }
}
