
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xulqna.Data.Contexts;
using Xulqna.Data.IRepositories;

namespace Xulqna.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {

#pragma warning disable

        internal XulqnaDbContext dbContext;
        private DbSet<T> dbSet;
        public GenericRepository(XulqnaDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();

        }
        public async Task<T> CreateAsync(T entity)
        {
            var entiry = await dbSet.AddAsync(entity);

            return entiry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            if (entity is null)
                return false;

            dbSet.Remove(entity);

            return true;
        }


        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? dbSet : dbSet.Where(expression);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry =  dbSet.Update(entity);

            return  entry.Entity;

        }
    }

}
