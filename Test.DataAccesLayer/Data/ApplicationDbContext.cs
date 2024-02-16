using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.DataAccesLayer
{
    //mack tast 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        public DbSet<Country> ? Countries { get; set; }    
    }
}
