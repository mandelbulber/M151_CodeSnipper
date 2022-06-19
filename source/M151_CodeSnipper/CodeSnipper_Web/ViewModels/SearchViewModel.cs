namespace CodeSnipper_Web.ViewModels
{
    public class SearchViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public List<SnippetViewModel> Snippets { get; set; } = new();
    }
}
