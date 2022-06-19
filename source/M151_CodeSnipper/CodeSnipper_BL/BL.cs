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

        public static void DeleteSnippet(string id)
        {
            CodeSnippet? dbCodeSnippet = _dbContext.CodeSnippets.FirstOrDefault(x => x.Id == id);
            if (dbCodeSnippet == null)
                return;

            _dbContext.CodeSnippets.Remove(dbCodeSnippet);
            _dbContext.SaveChanges();
        }

        public static List<CodeSnippet> GetPublicCodeSnippets()
        {
            return _dbContext.CodeSnippets.Where(x => x.IsPublic).ToList();
        }

        public static List<CodeSnippet> GetUsersCodeSnippets(string userId)
        {
            return _dbContext.CodeSnippets.Where(x => x.OwnerId == userId).ToList();
        }
        public static List<CodeSnippet> GetAllAvailableSnippets(string userId)
        {
            return _dbContext.CodeSnippets.Where(x => x.IsPublic || x.OwnerId == userId).ToList();
        }
    }
}