using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Department>().HasData(
          new Department
          {
              DepartmentId = 1,
              DepartmentName = "FrontEnd",
              CompanyName = "Bezohminds"
          },
           new Department
           {
               DepartmentId = 2,
               DepartmentName = "BackEnd",
               CompanyName = "Bezohminds"
           },
            new Department
            {
                DepartmentId = 3,
                DepartmentName = "FullStack",
                CompanyName = "Bezohminds"
            },
             new Department
             {
                 DepartmentId = 4,
                 DepartmentName = "IT",
                 CompanyName = "Bezohminds"
             },
              new Department
              {
                  DepartmentId = 5,
                  DepartmentName = "Sales",
                  CompanyName = "Bezohminds"
              }
           );
            base.OnModelCreating(modelBuilder);

        }
    }
}
