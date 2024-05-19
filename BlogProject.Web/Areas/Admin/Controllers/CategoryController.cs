using Microsoft.AspNetCore.Mvc;
using BlogProject.Entity.Dtos.Categories;
using BlogProject.Service.Services.Abstractions;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var category = await categoryServices.GetAllCategoriesNonDeleted();
            return View(category);
        }
    }
}
