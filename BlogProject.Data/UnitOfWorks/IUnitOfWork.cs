using BlogProject.Core.Entities;
using BlogProject.Data.Repositories.Abstractions;

namespace BlogProject.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable //Asenkron bir yapı olsun diye Async halini kullandık
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
