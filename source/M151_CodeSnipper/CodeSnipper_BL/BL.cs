using CodeSnipper_DAL.Models;
using CodeSnipper_DAL.Data;

namespace CodeSnipper_BL
{
    public static class BL
    {
        private static ApplicationDbContext _dbContext = new();

        public static void AddNewSnippet(CodeSnippet codeSnippet)
        {
            _dbContext.CodeSnippets.Add(codeSnippet);
            _dbContext.SaveChanges();
        }
    }
}