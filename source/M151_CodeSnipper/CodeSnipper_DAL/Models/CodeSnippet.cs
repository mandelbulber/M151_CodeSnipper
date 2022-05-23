using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnipper_DAL.Models
{
    public class CodeSnippet
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
        public string Language { get; set; } = string.Empty;

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
