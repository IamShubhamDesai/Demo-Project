using JobApplication.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Infra.Domain
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get;set; }
    }
}