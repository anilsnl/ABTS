using ABTS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABTS.BLL.Abstract
{
    public interface ICategoryManager
    {
        Task<bool> AddAsync(Category entity);
        Task<bool> DeleteAsync(Category entity);
        Task<bool> UpdateAsync(Category entity);
        Task<Category> UpdateAndGetAsync(Category entity);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
        Task<List<Category>> GetListAsync(Expression<Func<Category, bool>> expression = null);
    }
}
