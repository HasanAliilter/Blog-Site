using AutoMapper;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Entities;
using BlogProject.Entity.Enums;
using BlogProject.Service.Extensions;
using BlogProject.Service.Helpers.Images;
using BlogProject.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace BlogProject.Service.Services.Concretes
{
    public class ArticleServices : IArticleServices //Bazı filtreleme fonksiyonlarını buraya yazıyoruz
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal user;

        public ArticleServices(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = user.GetLoggedInUserId();
            var userEmail = user.GetLoggedInEmail();

            var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);

            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddDto.Title,articleAddDto.Content,articleAddDto.CategoryId,userId, userEmail, image.Id);

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);

            if(articleUpdateDto.Photo != null)
            {
                /*imageHelper.Delete(article.Image.FileName); // ilk olarak eski resmi siliyoruz

                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post); //sonrasında yeni resmi ekliyoruz
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;*/ // Bu kod veritabanındaki resmi güncellemek için değil o yeni resim oluşturup o resmi article ye ekleme işlemi

                imageHelper.Delete(article.Image.FileName); // ilk olarak eski resmi siliyoruz

                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post); //sonrasında yeni resmi ekliyoruz
                article.Image.FileName = imageUpload.FullName;
                article.Image.FileType = articleUpdateDto.Photo.ContentType;
                article.Image.UpdatedDate = DateTime.Now;
                article.Image.UpdatedBy = userEmail;
                await unitOfWork.GetRepository<Image>().UpdateAsync(article.Image);

            }
            
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;
            article.UpdatedDate = DateTime.Now;
            article.UpdatedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=> !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
    }
}
