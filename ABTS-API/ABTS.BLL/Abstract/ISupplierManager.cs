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
        Task<bool> AddAsync(Suppliers entity);
        Task<bool> DeleteAsync(Suppliers entity);
        Task<bool> UpdateAsync(Suppliers entity);
        Task<Suppliers> UpdateAndGetAsync(Suppliers entity);
        Task<Suppliers> GetAsync(Expression<Func<Suppliers, bool>> expression);
        Task<IQueryable<Suppliers>> GetListAsync(Expression<Func<Suppliers, bool>> expression = null);

    }
}
