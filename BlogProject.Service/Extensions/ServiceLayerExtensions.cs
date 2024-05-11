using BlogProject.Data.Context;
using BlogProject.Data.Repositories.Abstractions;
using BlogProject.Data.Repositories.Concretes;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Service.Services.Abstractions;
using BlogProject.Service.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IArticleServices, ArticleServices>();
            return services;
        }
    }
}
