using Microsoft.EntityFrameworkCore;
using Test.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Test.DataAccesLayer
{
    //mack tast 
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        public DbSet<Country> ? Countries { get; set; }
        public DbSet<Catagory>? Catagorys { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
