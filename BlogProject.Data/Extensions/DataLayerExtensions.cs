using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Data.Repositories.Abstractions;
using BlogProject.Data.Repositories.Concretes;

namespace BlogProject.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //IRepository e istek attığımda bana Repository nesnesini getir
            return services;
        }
    }
}
