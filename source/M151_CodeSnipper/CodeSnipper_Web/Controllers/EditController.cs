using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeSnipper_Web.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Index(string id)
        {
            CodeSnippet? codeSnippet = BL.GetSnippet(id);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (codeSnippet == null || codeSnippet.OwnerId != userId)
                return View("Error", id);

            SnippetViewModel snippetViewModel = codeSnippet.ConvertToSnippetViewModel();

            return View(snippetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public IActionResult Index(SnippetViewModel snippetViewModel)
        {
            CodeSnippet? dbCodeSnippet = BL.GetSnippet(snippetViewModel.Id);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (dbCodeSnippet == null ||
                dbCodeSnippet.OwnerId != userId)
                return RedirectToAction("Index", "Home");

            dbCodeSnippet = snippetViewModel.ConvertToCodeSnippet();
            if (!dbCodeSnippet.IsValid())
                return RedirectToAction("Index", "Home");

            BL.UpdateSnippet(dbCodeSnippet);

            return RedirectToAction("Index", "Home");
        }
    }
}
