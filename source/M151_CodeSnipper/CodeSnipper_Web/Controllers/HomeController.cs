using CodeSnipper_BL;
using CodeSnipper_DAL.Models;
using CodeSnipper_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeSnipper_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CodeSnippet> dbSnippets = BL.GetPublicCodeSnippets();
            List<SnippetViewModel> snippetViewModels = new();
            foreach(CodeSnippet codeSnippet in dbSnippets)
            {
                SnippetViewModel snippetViewModel = codeSnippet.ConvertToSnippetViewModel();
                snippetViewModels.Add(snippetViewModel);
            }
            return View(snippetViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}