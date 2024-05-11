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
using BlogProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data.UnitOfWorks;

namespace BlogProject.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config) //Proje ayağa kalakarken servisleri kaldırırz o nedenle servisi programc.cs e attık
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //IRepository e istek attığımda bana Repository nesnesini getir
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        } //başarısız olan işlemleri bize bildirecek bir yapı oluşturmalıyız
    }
}
