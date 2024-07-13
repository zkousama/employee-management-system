using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; }
    }
}