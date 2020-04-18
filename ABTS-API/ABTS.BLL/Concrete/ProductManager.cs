using ABTS.BLL.Abstract;
using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;
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
        public ProductManager(IProductDAL _productDal)
        {
            this._productDal = _productDal;
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
            return await _productDal.GetAsync(expression);
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
           return _productDal.GetProductList(columnName:columnName,page:page,pageSize:pageSize,isDesc:isDesc);
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
