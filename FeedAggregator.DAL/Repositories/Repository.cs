using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Entities;
using FeedAggregator.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FeedAggregator.DAL.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity: Entity
    {
        protected readonly FeedAggregatorDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected readonly IMapper mapper;

        public Repository(FeedAggregatorDbContext context, IMapper automapper)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            mapper = automapper;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await DbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception($"Entity with id: {id} not found when trying to update entity. Entity was no Deleted.");
            }

            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            try
            {
               DbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().CountAsync(predicate);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                          bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var findEntity = await DbSet.FindAsync(entity.Id);

            if (findEntity == null)
            {
                throw new Exception($"Entity {entity.GetType().Name} with id: {entity.Id} not found");
            }

            return mapper.Map(entity, findEntity);
        }

        public Task<List<TEntity>> GetAllEntities(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (include != null)
            {
                query = include(query);
            }

            return query.ToListAsync();
        }
    }
}
