using BlogProject.Core.Entities;
using BlogProject.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable //Asenkron bir yapı olsun diye Async halini kullandık
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
