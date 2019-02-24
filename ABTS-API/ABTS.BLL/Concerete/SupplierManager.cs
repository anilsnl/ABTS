using ABTS.BLL.Abstract;
using ABTS.DAL.Abstract;
using ABTS.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.BLL.Concerete
{
    public class SupplierManager:ISupplierManager
    {
        private readonly ISupplierDAL _supplierDal;
        public SupplierManager(ISupplierDAL _supplierDal)
        {
            this._supplierDal = _supplierDal;
        }
        public async Task<bool> AddAsync(Suppliers entity)
        {
            return await _supplierDal.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Suppliers entity)
        {
            return await _supplierDal.DeleteAsync(entity);
        }

        public async Task<Suppliers> GetAsync(Expression<Func<Suppliers, bool>> expression)
        {
            return await _supplierDal.GetAsync(expression);
        }

        public async Task<IQueryable<Suppliers>> GetListAsync(Expression<Func<Suppliers, bool>> expression = null)
        {
            return await _supplierDal.GetListAsync(expression);
        }

        public async Task<Suppliers> UpdateAndGetAsync(Suppliers entity)
        {
            return await _supplierDal.UpdateAndGetAsync(entity);
        }

        public async Task<bool> UpdateAsync(Suppliers entity)
        {
            return await _supplierDal.UpdateAsync(entity);
        }
    }
}
