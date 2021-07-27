using DataAccessLayer.Entities.Base;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class Repository : IRepository
    {
        private readonly AppDBContext dbContext;

        public Repository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> AddAsync<T>(T element) where T : BaseEntity
        {
            var newElementTask = await dbContext.Set<T>().AddAsync(element);
            await dbContext.SaveChangesAsync();
            return newElementTask.Entity;
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            await dbContext.Set<T>().AddRangeAsync(range);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T element) where T : BaseEntity
        {
            dbContext.Set<T>().Remove(element);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            dbContext.Set<T>().RemoveRange(range);
            await dbContext.SaveChangesAsync();
        }

        public T Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> query = dbContext.Set<T>();
            return query.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetRange<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> query = dbContext.Set<T>();
            return query.Where(expression);
        }

        public async Task UpdateAsync<T>(T element) where T : BaseEntity
        {
            dbContext.Set<T>().Update(element);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            dbContext.Set<T>().UpdateRange(range);
            await dbContext.SaveChangesAsync();
        }
    }
}
