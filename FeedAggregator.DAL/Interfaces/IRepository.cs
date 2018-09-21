using FeedAggregator.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FeedAggregator.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                             bool disableTracking = true);
        Task<List<TEntity>> GetAllEntities(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}
