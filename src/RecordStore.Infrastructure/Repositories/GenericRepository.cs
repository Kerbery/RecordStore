using Microsoft.EntityFrameworkCore;
using RecordStore.Core.Entities;
using RecordStore.Core.Interfaces;
using RecordStore.Infrastructure.Data;
using System.Linq.Expressions;

namespace RecordStore.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private protected ApplicationDbContext _context;
        private protected DbSet<T> _table;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T?> GetAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();

            if (includes is not null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            return await _table.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();

            if (includes is not null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();

            if (includes is not null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.Where(filter).ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await _table.FindAsync(id);
            if (entity is not null)
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
