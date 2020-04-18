using ABTS.BLL.Abstract;
using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABTS.BLL.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDAL _productDal;
        private readonly ICategoryDAL _categoryDAL;
        private readonly ISupplierDAL _supplierDAL;
        public ProductManager(IProductDAL _productDal,
            ICategoryDAL categoryDAL,
            ISupplierDAL supplierDAL)
        {
            this._productDal = _productDal;
            _categoryDAL = categoryDAL;
            _supplierDAL = supplierDAL;
        }

        public async Task<bool> AddAsync(Product entity)
        {
            return await _productDal.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            return await _productDal.DeleteAsync(entity);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var data = await _productDal.GetAsync(expression);
            data.Category = await _categoryDAL.GetAsync(a => a.CategoryId == data.CategoryId);
            data.Supplier = await _supplierDAL.GetAsync(a => a.SupplierId == data.SupplierId);
            return data;
        }

        public IQueryable<Product> GetList(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Product>> GetListAsync(Expression<Func<Product, bool>> expression = null)
        {
            return await _productDal.GetListAsync(expression);
        }

        public IQueryable<Product> GetProductList(string columnName = null, int page = 1, int pageSize = 0, bool isDesc = false)
        {
            return _productDal.GetProductList(columnName: columnName, page: page, pageSize: pageSize, isDesc: isDesc);
        }

        public async Task<Product> UpdateAndGetAsync(Product entity)
        {
            return await _productDal.UpdateAndGetAsync(entity);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            return await _productDal.UpdateAsync(entity);
        }
    }
}
