using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using library_manager.Domain.Abstractions;
using library_manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using library_manager.Persistance.Data;

namespace library_manager.Persistance.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly LibraryDbContext _context;
        protected readonly DbSet<T> _entities;

        public EFRepository(LibraryDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _entities.Remove(entity), cancellationToken);
            
            await _context.SaveChangesAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            return await _entities.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
             return await Task.Run(()=> _entities.ToListAsync(), cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if(includesProperties.Any()) //если есть элементы
            {
                foreach(Expression<Func<T,object>>? included in
                    includesProperties )
                {
                    query = query.Include(included);
                }
            }

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }


        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
