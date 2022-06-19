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
        [ValidateAntiForgeryToken]
        public IActionResult Index(SnippetViewModel snippetViewModel)
        {
            if (snippetViewModel == null)
                return RedirectToAction("Index", "Home");

            CodeSnippet codeSnippet = snippetViewModel.ConvertToCodeSnippet();
            codeSnippet.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!codeSnippet.IsValid())
                return RedirectToAction("Index", "Home");

            BL.AddNewSnippet(codeSnippet);

            return RedirectToAction("Index", "Home");
        }
    }
}
