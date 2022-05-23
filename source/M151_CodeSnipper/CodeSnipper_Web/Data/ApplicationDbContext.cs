using CodeSnipper_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeSnipper_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CodeSnippet> CodeSnippets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}