using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Abstractions
{
    public interface IRepository<T>  where T: Entity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, 
            params Expression<Func<T, object>>[]? includesProperties);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, 
            CancellationToken cancellationToken = default, 
            params Expression<Func<T, object>>[]? includesProperties);

        //Добавление новой сущности
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        //Изменение сущности
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        //Удаление сушности
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        //Поиск первой сущности, удовлетворяющей условию отбора.
        //Если сущность не найдена, будет возвращено значение по умолчанию
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, 
            CancellationToken cancellationToken = default);
        
    }
}
