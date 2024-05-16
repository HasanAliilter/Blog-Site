using AutoMapper;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Entities;
using BlogProject.Service.Services.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogProject.Service.Services.Concretes
{
    public class ArticleServices : IArticleServices //Bazı filtreleme fonksiyonlarını buraya yazıyoruz
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = Guid.Parse("46E64AA1-EF33-4ADE-84FD-E029A5464469");
            var imageId = Guid.Parse("F91B9913-A95D-4C7C-A204-E1D32A151C72");

            var article = new Article(articleAddDto.Title,articleAddDto.Content,articleAddDto.CategoryId,userId, imageId);
            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }
        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }
        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=> !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
    }
}
