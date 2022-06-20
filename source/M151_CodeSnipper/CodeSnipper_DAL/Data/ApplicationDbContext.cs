using CodeSnipper_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeSnipper_DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CodeSnippet> CodeSnippets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=.\\;Database=CodeSnipper;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}