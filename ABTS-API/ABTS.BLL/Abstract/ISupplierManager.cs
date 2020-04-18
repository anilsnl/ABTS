using ABTS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABTS.BLL.Abstract
{
    public interface ISupplierManager
    {
        Task<bool> AddAsync(Supplier entity);
        Task<bool> DeleteAsync(Supplier entity);
        Task<bool> UpdateAsync(Supplier entity);
        Task<Supplier> UpdateAndGetAsync(Supplier entity);
        Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> expression);
        Task<IQueryable<Supplier>> GetListAsync(Expression<Func<Supplier, bool>> expression = null);

    }
}
