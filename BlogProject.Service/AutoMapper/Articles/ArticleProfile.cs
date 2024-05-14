using AutoMapper;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.AutoMapper.Articles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Article>().ReverseMap(); //ArticleDto ve Article yi birbiriyle eşledik
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
        }
    }
}
