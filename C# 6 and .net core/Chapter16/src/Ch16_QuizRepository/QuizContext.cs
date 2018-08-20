using Ch16_QuizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Ch16_QuizRepository
{
    public class QuizContext:DbContext
    {
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        //最佳实践是给构造函数中传入一个DbContextOptions参数，可用于以后指定数据库provider
        public QuizContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasMany<Question>().WithOne(quest => quest.Quiz);
            base.OnModelCreating(modelBuilder);
        }
    }
}
