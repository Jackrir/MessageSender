using DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetRange<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;

        T Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;

        Task<T> AddAsync<T>(T element) where T : BaseEntity;

        Task AddRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity;

        Task DeleteRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity;

        Task DeleteAsync<T>(T element) where T : BaseEntity;

        Task UpdateAsync<T>(T element) where T : BaseEntity;

        Task UpdateRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity;
    }
}
