using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;

namespace CodeSnipper_Web
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a CodeSnippet to a SnippetViewModel. Does fill in the Username of the owner in OwnerUsername.
        /// </summary>
        public static SnippetViewModel ConvertToSnippetViewModel(this CodeSnippet codeSnippet)
        {
            SnippetViewModel snippetViewModel = new()
            {
                Id = codeSnippet.Id,
                Title = codeSnippet.Title,
                Content = codeSnippet.Content,
                Language = codeSnippet.Language,
                OwnerUsername = BL.GetUsername(codeSnippet.OwnerId),
                IsPublic = codeSnippet.IsPublic
            };
            return snippetViewModel;
        }
        
        /// <summary>
        /// Converts a SnippetViewModel to a CodeSnippet. Does not fill OwnerUsername into OwnerId.
        /// </summary>
        public static CodeSnippet ConvertToCodeSnippet(this SnippetViewModel snippetViewModel)
        {
            CodeSnippet codeSnippet = new()
            {
                Title = snippetViewModel.Title,
                Content = snippetViewModel.Content,
                Language = snippetViewModel.Language,
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
