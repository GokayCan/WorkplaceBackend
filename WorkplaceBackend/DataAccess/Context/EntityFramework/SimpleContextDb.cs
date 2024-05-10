using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyResponsible> CompanyResponsibles { get; set; }
        public DbSet<CompanyStaff> CompanyStaffs { get; set; }
        public DbSet<CompanyStudent> CompanyStudents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Programming> Programmings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentInterest> StudentInterests { get; set; }
        public DbSet<StudentLanguage> StudentLanguages { get; set; }
        public DbSet<StudentProgramming> StudentProgrammings { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Lesson> Lessons{ get; set; }
        public DbSet<Semester> Semesters{ get; set; }
        public DbSet<StudentLesson> StudentLessons{ get; set; }
    }
}
