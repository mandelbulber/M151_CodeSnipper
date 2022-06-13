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
            CodeSnippet? codeSnippet = BL.GetCodeSnippet(id);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (codeSnippet == null || codeSnippet.OwnerId != userId)
                return View("Error", id);

            SnippetViewModel snippetViewModel = new()
            {
                Id = codeSnippet.Id,
                Title = codeSnippet.Title,
                Content = codeSnippet.Content,
                IsPublic = codeSnippet.IsPublic,
                Language = codeSnippet.Language
            };

            return View(snippetViewModel);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Index(SnippetViewModel snippetViewModel)
        {
            CodeSnippet? dbCodeSnippet = BL.GetCodeSnippet(snippetViewModel.Id);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (dbCodeSnippet == null || dbCodeSnippet.OwnerId != userId)
                return RedirectToAction("Index", "Home");

            dbCodeSnippet.Title = snippetViewModel.Title;
            dbCodeSnippet.Content = snippetViewModel.Content;
            dbCodeSnippet.IsPublic = snippetViewModel.IsPublic;
            dbCodeSnippet.Language = snippetViewModel.Language;

            BL.UpdateSnippet(dbCodeSnippet);

            return RedirectToAction("Index", "Home");
        }
    }
}
