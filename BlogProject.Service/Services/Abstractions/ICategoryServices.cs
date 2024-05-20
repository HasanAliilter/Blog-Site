using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Abstractions
{
    public interface ICategoryServices
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid categoryId);
    }
}
