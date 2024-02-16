using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.DataAccesLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        public DbSet<Country> ? Countries { get; set; }    
    }
}
