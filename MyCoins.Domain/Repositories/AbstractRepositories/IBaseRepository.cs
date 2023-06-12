using System.Linq.Expressions;

namespace MyCoins.Domain.Repositories.AbstractRepositories
{
    public interface IBaseRepository<T>
    {
        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        T Delete(T entity);
        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> FilterAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        T Update(T entity);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
