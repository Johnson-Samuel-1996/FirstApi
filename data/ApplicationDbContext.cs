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
    }
}
