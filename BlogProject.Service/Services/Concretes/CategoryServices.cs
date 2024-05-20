using AutoMapper;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Concretes
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal user;

        public CategoryServices(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = user.GetLoggedInEmail();
            var category = new Category(categoryAddDto.Name, userEmail);

            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

            category.Name = categoryUpdateDto.Name;
            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }
        public async Task<string> SafeDeleteArticleAsync(Guid categoryId)
        {
            var userEmail = user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }
    }
}
