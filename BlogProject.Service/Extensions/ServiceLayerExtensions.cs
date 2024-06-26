﻿using BlogProject.Service.FluentValidations;
using BlogProject.Service.Helpers.Images;
using BlogProject.Service.Services.Abstractions;
using BlogProject.Service.Services.Concretes;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace BlogProject.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddScoped<IArticleServices, ArticleServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Mevcut olan kullanıcıyı metodlara bazı yönlendirmelerle bulmamızı sağlıyor

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
            return services;
        }
    }
}
