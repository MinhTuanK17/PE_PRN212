using FPTBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FPTBusiness
{
    public class MyStudentDbContext : DbContext
    {
        public MyStudentDbContext() { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStringDB"));
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>().HasData(
                  new Student { StudentId = 1, StudentCode = "DE170526", StudentName = "Dương Đức Anh" },
                  new Student { StudentId = 2, StudentCode = "DE180229", StudentName = "Phan Thành Chung" },
                  new Student { StudentId = 4, StudentCode = "DE180391", StudentName = "Hoàng Công Minh" },
                  new Student { StudentId = 5, StudentCode = "DE170523", StudentName = "Ngô Đông Quân" }
              );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = ".NET" },
                new Subject { SubjectId = 2, SubjectName = "JAVA" },
                new Subject { SubjectId = 3, SubjectName = "NODEJS" },
                new Subject { SubjectId = 4, SubjectName = "ANDROID" }
            );


            modelBuilder.Entity<Grade>()
                 .Property(b => b.Point)
                 .HasColumnType("money");

            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeId = 1, Point = 6, StudentId = 1, SubjectId = 1, DateCreate = DateTime.Now },
                new Grade { GradeId = 2, Point = 6, StudentId = 2, SubjectId = 2, DateCreate = DateTime.Now },
                new Grade { GradeId = 3, Point = 5, StudentId = 2, SubjectId = 1, DateCreate = DateTime.Now },
                new Grade { GradeId = 4, Point = 7, StudentId = 4, SubjectId = 4, DateCreate = DateTime.Now },
                new Grade { GradeId = 5, Point = 7, StudentId = 5, SubjectId = 4, DateCreate = DateTime.Now },
                new Grade { GradeId = 6, Point = 9, StudentId = 4, SubjectId = 3, DateCreate = DateTime.Now }
            );
        }
    }
}
