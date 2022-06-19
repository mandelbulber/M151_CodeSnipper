using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeSnipper_Web.Controllers
{
    [Authorize]
    public class MySnippetsController : Controller
    {
        public IActionResult Index()
        {
            List<CodeSnippet> dbSnippets = BL.GetUsersCodeSnippets(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<SnippetViewModel> snippetViewModels = new();
            foreach (CodeSnippet codeSnippet in dbSnippets)
            {
                SnippetViewModel snippetViewModel = codeSnippet.ConvertToSnippetViewModel();
                snippetViewModels.Add(snippetViewModel);
            }
            return View(snippetViewModels);
        }
    }
}
