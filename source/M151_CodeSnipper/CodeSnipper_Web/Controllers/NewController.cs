using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeSnipper_Web.Controllers
{
    [Authorize]
    public class NewController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            SnippetViewModel snippetViewModel = new();
            return View(snippetViewModel);
        }

        [HttpPost]
        public IActionResult Index(SnippetViewModel snippetViewModel)
        {
            CodeSnippet codeSnippet = new()
            {
                Title = snippetViewModel.Title,
                Content = snippetViewModel.Content,
                OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Language = snippetViewModel.Language,
                IsPublic = snippetViewModel.IsPublic
            };
            BL.AddNewSnippet(codeSnippet);

            return RedirectToAction("Index", "Home");
        }
    }
}
