using ABTS.BLL.Abstract;
using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.BLL.Concrete
{
    public class SupplierManager:ISupplierManager
    {
        private readonly ISupplierDAL _supplierDal;
        public SupplierManager(ISupplierDAL _supplierDal)
        {
            this._supplierDal = _supplierDal;
        }
        public async Task<bool> AddAsync(Supplier entity)
        {
            return await _supplierDal.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Supplier entity)
        {
            return await _supplierDal.DeleteAsync(entity);
        }

        public async Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> expression)
        {
            return await _supplierDal.GetAsync(expression);
        }

        public async Task<IQueryable<Supplier>> GetListAsync(Expression<Func<Supplier, bool>> expression = null)
        {
            return await _supplierDal.GetListAsync(expression);
        }

        public async Task<Supplier> UpdateAndGetAsync(Supplier entity)
        {
            return await _supplierDal.UpdateAndGetAsync(entity);
        }

        public async Task<bool> UpdateAsync(Supplier entity)
        {
            return await _supplierDal.UpdateAsync(entity);
        }
    }
}
