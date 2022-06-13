using CodeSnipper_DAL.Models;

namespace CodeSnipper_Web.ViewModels
{
    public class SnippetViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public bool IsPublic { get; set; }

        public static List<string> Languages { get; } = CodeSnippet.Languages;
    }
}
