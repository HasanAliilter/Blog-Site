using AutoMapper;
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
        private readonly IMapper mapper;

        public ArticleController(IArticleServices articleServices, ICategoryServices categoryServices, IMapper mapper)
        {
            this.articleServices = articleServices;
            this.categoryServices = categoryServices;
            this.mapper = mapper;
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
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
            var categories = await categoryServices.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId) //Buradaki articleId ile index teki asp-route-articleId="@article.Id" özelliği bind edilir
        {
            var article = await articleServices.GetArticlesWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryServices.GetAllCategoriesNonDeleted();
            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto) //Buradaki articleId ile index teki asp-route-articleId="@article.Id" özelliği bind edilir
        {
            await articleServices.UpdateArticleAsync(articleUpdateDto);

            var categories = await categoryServices.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await articleServices.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
