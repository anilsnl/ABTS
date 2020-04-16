using ABTS.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.BLL.Abstract
{
    public interface IProductManager
    {
        Task<bool> AddAsync(Products entity);
        Task<bool> DeleteAsync(Products entity);
        Task<bool> UpdateAsync(Products entity);
        Task<Products> UpdateAndGetAsync(Products entity);
        Task<Products> GetAsync(Expression<Func<Products, bool>> expression);
        Task<IQueryable<Products>> GetListAsync(Expression<Func<Products, bool>> expression = null);
        IQueryable<Products> GetList(Expression<Func<Products, bool>> expression=null);
        IQueryable<Products> GetProductList(string columnName = null, int page = 1, int pageSize = 0, bool isDesc = false);
    }
}
