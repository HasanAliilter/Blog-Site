using BlogProject.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleServices;

        public ArticleController(IArticleServices articleServices)
        {
            this.articleServices = articleServices;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleServices.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
    }
}
