namespace CodeSnipper_Web.ViewModels
{
    public class SnippetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public string Language { get; set; }

        public static List<string> Languages { get; } = new()
        {
            "C",
            "C++",
            "C#",
            "C# Script",
            "VB",
            "Java",
            "HTML",
            "CSS",
            "JavaScript",
            "PHP",
            "Python",
            "Rust",
            "SQL (General)",
            "SQL (MySQL)",
            "SQL (MSSQL)"
        };
    }
}
