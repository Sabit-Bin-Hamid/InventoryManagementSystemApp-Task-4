using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.IService
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Save(T entity);
        Task SaveAll(IEnumerable<T> entities);

        Task Update(T entity);

        void Remove(T entity);
        void RemoveAll(IEnumerable<T> entities);
    }
}
