using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstCodeFirstApp.NewSample;

namespace FirstCodeFirstApp
{
    public class Context : DbContext
    {
        public Context()
            : base("name=FirstCodeFirstApp")
        {
        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<PayWay> PayWays { get; set; }
        public DbSet<DonatorType> DonatorTypes { get; set; }

        public DbSet<Person> People { set; get; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Donator>().ToTable("Donators").HasKey(m => m.DonatorId);//映射到表Donators,DonatorId当作主键对待
            //modelBuilder.Entity<Donator>().Property(m => m.DonatorId).HasColumnName("Id");//映射到数据表中的主键名为Id而不是DonatorId
            //modelBuilder.Entity<Donator>().Property(m => m.Name)
            //    .IsRequired()//设置Name是必须的，即不为null,
            //    .IsUnicode()//设置Name列为Unicode字符
            //    .HasMaxLength(10);//最大长度为10
            modelBuilder.Configurations.Add(new DonatorMap());
            modelBuilder.Configurations.Add(new DonatorTypeMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
