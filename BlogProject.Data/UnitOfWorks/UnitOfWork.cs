using BlogProject.Data.Context;
using BlogProject.Data.Repositories.Abstractions;
using BlogProject.Data.Repositories.Concretes;

namespace BlogProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork //UnitOfWork yapısı bir dizi işlemi birlikte işlemeye yarar bu yapı işlemlerin birlikte başarısız veya başarılı olduğu durumlarda kullanışlıdır
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>() //Bu yapı repository sınıfları içindeki fonksiyonlara ulaşmak için
        {
            return new Repository<T>(dbContext);
        }
    }
}
