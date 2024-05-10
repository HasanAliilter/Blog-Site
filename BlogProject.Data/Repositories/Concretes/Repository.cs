using BlogProject.Core.Entities;
using BlogProject.Data.Context;
using BlogProject.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProject.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); } //T yerine gelecek olan entity i set etme işlemini Table ye atadım
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) //bir adet fonksiyon yaz ve entity değeri ver ve boolean değer ger dönsün bize çünkü where yazacaz gibi düşün
        {
            IQueryable<T> query = Table; //veri tabanı sorgularında IQueryable kullanılır
            if(predicate != null) //predicate bütün nesneleri includeProperties ise ilişkilileri alır
                query = query.Where(predicate);

            if(includeProperties.Any())
                foreach(var item in includeProperties)
                    query = query.Include(item); //ilişkili nesnelerin yüklenmesi için gerekli bir fonksiyondur

            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity) // veri tabanına entity eklemek için
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync(); //Firstordefaultasync den farkı eğer bir değer gelmezse hata alınır
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task .Run(() => Table.Update(entity)); //Update normalde async olmaz ama biz yapıyı bozmamak adına zorla async yaptık
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
