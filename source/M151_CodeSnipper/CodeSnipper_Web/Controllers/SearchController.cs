using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeSnipper_Web.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string language, string title)
        {
            List<CodeSnippet> dbSnippets = BL.GetAllAvailableSnippets(User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Where(x => (language == "All" || x.Language == language) && (title == null || x.Title.ToUpper().Contains(title.ToUpper())))
                .ToList();
            SearchViewModel searchViewModel = new()
            {
                Language = language,
                Title = title
            };
            foreach (CodeSnippet codeSnippet in dbSnippets)
            {
                searchViewModel.Snippets.Add(codeSnippet.ConvertToSnippetViewModel());
            }
            return View(searchViewModel);
        }
    }
}
