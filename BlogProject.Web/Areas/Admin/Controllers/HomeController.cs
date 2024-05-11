using BlogProject.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleServices articleService;

        public HomeController(IArticleServices articleService)
        {
            this.articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var article = await articleService.GetAllArticlesAsync();
            return View(article);
        }
    }
}
