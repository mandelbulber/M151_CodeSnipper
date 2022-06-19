using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;

namespace CodeSnipper_Web
{
    public static class Extensions
    {
        public static SnippetViewModel ConvertToSnippetViewModel(this CodeSnippet codeSnippet)
        {
            SnippetViewModel snippetViewModel = new()
            {
                Id = codeSnippet.Id,
                Title = codeSnippet.Title,
                Content = codeSnippet.Content,
                Language = codeSnippet.Language,
                OwnerId = codeSnippet.OwnerId,
                IsPublic = codeSnippet.IsPublic
            };
            return snippetViewModel;
        }

        public static CodeSnippet ConvertToCodeSnippet(this SnippetViewModel snippetViewModel)
        {
            CodeSnippet codeSnippet = new()
            {
                Title = snippetViewModel.Title,
                Content = snippetViewModel.Content,
                Language = snippetViewModel.Language,
                OwnerId = snippetViewModel.OwnerId,
                IsPublic = snippetViewModel.IsPublic
            };
            return codeSnippet;
        }

        /// <summary>
        /// Validates for nullability and for Title, Content, Language and OwnerId.
        /// </summary>
        public static bool IsValid(this CodeSnippet codeSnippet)
        {
            if (codeSnippet == null ||
                string.IsNullOrWhiteSpace(codeSnippet.Title) ||
                string.IsNullOrWhiteSpace(codeSnippet.Content) ||
                string.IsNullOrWhiteSpace(codeSnippet.Language) ||
                string.IsNullOrWhiteSpace(codeSnippet.OwnerId))
            {
                return false;
            }
            return true;
        }
    }
}
