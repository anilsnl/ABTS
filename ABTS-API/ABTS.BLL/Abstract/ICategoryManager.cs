using ABTS.Entities.Concerete;
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
        Task<bool> AddAsync(Categories entity);
        Task<bool> DeleteAsync(Categories entity);
        Task<bool> UpdateAsync(Categories entity);
        Task<Categories> UpdateAndGetAsync(Categories entity);
        Task<Categories> GetAsync(Expression<Func<Categories, bool>> expression);
        Task<IQueryable<Categories>> GetListAsync(Expression<Func<Categories, bool>> expression = null);
    }
}
