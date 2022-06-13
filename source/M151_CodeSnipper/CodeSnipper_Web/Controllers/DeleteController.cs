using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeSnipper_Web.Controllers
{
    [Authorize]
    public class DeleteController : Controller
    {
        [HttpPost]
        public IActionResult Index(string id)
        {
            CodeSnippet? codeSnippet = BL.GetSnippet(id);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (codeSnippet == null || codeSnippet.OwnerId != userId)
                return RedirectToAction("Index", "Home");

            BL.DeleteSnippet(codeSnippet.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
