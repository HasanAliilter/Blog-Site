using BlogProject.Service.Services.Abstractions;
using BlogProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleServices articleService;

        public HomeController(ILogger<HomeController> logger, IArticleServices articleService)
        {
            _logger = logger;
            this.articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var article = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(article);
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
