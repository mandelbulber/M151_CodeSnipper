using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnipper_DAL.Models
{
    public class CodeSnippet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [Required]
        public string Language { get; set; } = string.Empty;
        public bool IsPublic { get; set; }

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
