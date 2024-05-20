using AutoMapper;
using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstractions;
using BlogProject.Web.ResultMessages;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;
        private readonly IMapper mapper;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toastNotification;

        public CategoryController(ICategoryServices categoryServices, IMapper mapper, IValidator<Category> validator, IToastNotification toastNotification)
        {
            this.categoryServices = categoryServices;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var category = await categoryServices.GetAllCategoriesNonDeleted();
            return View(category);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryServices.CreateCategoryAsync(categoryAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            else
            {
                BlogProject.Service.Extensions.FluentValidationExtensions.AddToModelState(result, this.ModelState); // Burada BlogProject.Service.Extensions sınıfını kullanıyoruz
                return View();
            }
        }

    }
}
