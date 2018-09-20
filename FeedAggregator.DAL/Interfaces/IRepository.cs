using FeedAggregator.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FeedAggregator.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetEntityByIdAsync(int Id);
        Task<IEnumerable<TEntity>> GetAllEntities();
    }
}
