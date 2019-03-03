using ABTS.DAL.Abstract;
using ABTS.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ABTS.DAL.Concrete.EF
{
    public abstract class EFBaseDAL<TEntity> : IBaseDAL<TEntity> where TEntity : class, IEntity, new()
    {
        NorthwindContext _context;

        protected EFBaseDAL(NorthwindContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            var res = await _context.AddAsync(entity);
            return res.State == Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            var res = await Task.Factory.StartNew(() => _context.Remove(entity));
            return res.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return _context.Set<TEntity>();
            else
                return _context.Set<TEntity>().Where(expression);
        }

        public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return await Task.Factory.StartNew(() => _context.Set<TEntity>());
            else
                return await Task.Factory.StartNew(() => _context.Set<TEntity>().Where(expression));
        }

        public async Task<TEntity> UpdateAndGetAsync(TEntity entity)
        {
            var res = await Task.Factory.StartNew(()=>_context.Update(entity));
            return res.State == EntityState.Modified ? entity : null;
        }
        public  async Task<bool> UpdateAsync(TEntity entity)
        {
            var res = await Task.Factory.StartNew(() => _context.Update(entity));
            return res.State == EntityState.Modified;
        }
    }
}
