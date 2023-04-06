using IMSInterfaceLayer.DataContext;
using IMSInterfaceLayer.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly AppDbContext db;

        public BaseService(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public async Task<T> Get(int Id)
        {
            return await db.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public void Remove(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void RemoveAll(IEnumerable<T> entities)
        {
            db.Set<T>().RemoveRange(entities);
            db.SaveChanges();
        }

        public async Task Save(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task SaveAll(IEnumerable<T> entities)
        {

            await db.Set<T>().AddRangeAsync(entities);
            await db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
           await db.SaveChangesAsync();
        }
    }
}
