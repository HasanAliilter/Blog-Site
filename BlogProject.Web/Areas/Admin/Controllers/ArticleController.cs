using AutoMapper;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstractions;
using BlogProject.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleServices;
        private readonly ICategoryServices categoryServices;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toastNotification;

        public ArticleController(IArticleServices articleServices, ICategoryServices categoryServices, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            this.articleServices = articleServices;
            this.categoryServices = categoryServices;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
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
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleServices.CreateArticleAsync(articleAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "Başarılı!"});
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await categoryServices.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
            }
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
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleServices.UpdateArticleAsync(articleUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions { Title = "Başarılı!"});
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await categoryServices.GetAllCategoriesNonDeleted();
                articleUpdateDto.Categories = categories;
                return View(articleUpdateDto);
            }
                        
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleServices.SafeDeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
