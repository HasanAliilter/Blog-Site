using BlogProject.Entity.Dtos.Articles;
using BlogProject.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleServices;
        private readonly ICategoryServices categoryServices;

        public ArticleController(IArticleServices articleServices, ICategoryServices categoryServices)
        {
            this.articleServices = articleServices;
            this.categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleServices.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryServices.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            await articleServices.CreateArticleAsync(articleAddDto);
            RedirectToAction("Index", "Article", new { Area = "Admin" });
            var categories = await categoryServices.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
    }
}
