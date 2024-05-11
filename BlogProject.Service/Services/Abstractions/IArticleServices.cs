using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Abstractions
{
    public interface IArticleServices
    {
        Task<List<Article>> GetAllArticlesAsync();
    }
}
