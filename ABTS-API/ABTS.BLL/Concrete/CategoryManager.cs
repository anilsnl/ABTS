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
    public class CategoryManager:ICategoryManager
    {
        private readonly ICategoryDAL _categoryDal;
        public CategoryManager(ICategoryDAL _categoryDal)
        {
            this._categoryDal = _categoryDal;
        }
        public async Task<bool> AddAsync(Category entity)
        {
            return await _categoryDal.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Category entity)
        {
            return await _categoryDal.DeleteAsync(entity);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryDal.GetAsync(expression);
        }

        public async Task<IQueryable<Category>> GetListAsync(Expression<Func<Category, bool>> expression = null)
        {
            return await _categoryDal.GetListAsync(expression);
        }

        public async Task<Category> UpdateAndGetAsync(Category entity)
        {
            return await _categoryDal.UpdateAndGetAsync(entity);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            return await _categoryDal.UpdateAsync(entity);
        }
    }
}
