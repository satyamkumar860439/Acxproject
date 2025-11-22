using Acxproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Acxproject.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CRMUser> CRMUsers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
