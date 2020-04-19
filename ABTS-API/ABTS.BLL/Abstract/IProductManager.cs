using ABTS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.BLL.Abstract
{
    public interface IProductManager
    {
        Task<bool> AddAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
        Task<bool> UpdateAsync(Product entity);
        Task<Product> UpdateAndGetAsync(Product entity);
        Task<Product> GetAsync(Expression<Func<Product, bool>> expression);
        Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> expression = null);
        IQueryable<Product> GetList(Expression<Func<Product, bool>> expression=null);
        IQueryable<Product> GetProductList(string columnName = null, int page = 1, int pageSize = 0, bool isDesc = false);
    }
}
