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

        public static CodeSnippet? GetSnippet(string id)
        {
            CodeSnippet? codeSnippet = _dbContext.CodeSnippets.FirstOrDefault(x => x.Id == id);
            return codeSnippet;
        }

        public static void UpdateSnippet(CodeSnippet codeSnippet)
        {
            CodeSnippet? dbCodeSnippet = _dbContext.CodeSnippets.FirstOrDefault(x => x.Id == codeSnippet.Id);
            if (dbCodeSnippet == null)
                return;

            dbCodeSnippet.Title = codeSnippet.Title;
            dbCodeSnippet.Content = codeSnippet.Content;
            dbCodeSnippet.Language = codeSnippet.Language;
            dbCodeSnippet.IsPublic = codeSnippet.IsPublic;

            _dbContext.SaveChanges();
        }
    }
}