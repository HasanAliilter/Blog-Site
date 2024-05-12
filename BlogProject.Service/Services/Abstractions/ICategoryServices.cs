using BlogProject.Entity.Dtos.Categories;
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
    }
}
