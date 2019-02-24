using ABTS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.DAL.Abstract
{
    public interface IBaseDAL<T> where T: class,IEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> UpdateAndGetAsync(T entity);
        Task<T> GetAsync(Expression<Func<T,bool>> expression);
        Task<IQueryable<T>> GetListAsync(Expression<Func<T,bool>> expression=null);
        IQueryable<T> GetList(Expression<Func<T,bool>> expression=null);

    }
}
