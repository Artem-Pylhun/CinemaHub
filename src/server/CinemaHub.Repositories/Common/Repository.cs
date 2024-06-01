using CinemaHub.Domain.Context;
using CinemaHub.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Repositories.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected CinemaContext _ctx;
        protected DbSet<TEntity> dbSet;

        public Repository(CinemaContext ctx)
        {
            _ctx = ctx;
            dbSet = _ctx.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await dbSet.ToListAsync();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }
        public virtual async Task DeleteAsync(TKey id)
        {
            dbSet.Remove(await dbSet.FindAsync(id));
            await SaveAsync();

        }
        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task SaveAsync() => await _ctx.SaveChangesAsync();
    }
}
