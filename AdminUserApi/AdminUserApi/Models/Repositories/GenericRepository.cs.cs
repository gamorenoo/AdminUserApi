using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdminUserApi.Models.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdminUserApi.Models.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly AdminUserDBcontext _AdminUserDBcontext;
        public GenericRepository(AdminUserDBcontext DeportesDBcontext)
        {
            _AdminUserDBcontext = DeportesDBcontext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntry = await _AdminUserDBcontext.AddAsync(entity);
            await _AdminUserDBcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _AdminUserDBcontext.AddRangeAsync(entity);
            await _AdminUserDBcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _AdminUserDBcontext.Remove(entity);
            return await _AdminUserDBcontext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _AdminUserDBcontext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _AdminUserDBcontext.Set<TEntity>().ToListAsync() : _AdminUserDBcontext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _AdminUserDBcontext.Update(entity);
            await _AdminUserDBcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _AdminUserDBcontext.UpdateRange(entity);
            await _AdminUserDBcontext.SaveChangesAsync();
            return entity;
        }
    }
}
