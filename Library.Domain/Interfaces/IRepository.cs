using System.Linq.Expressions;

namespace Library.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
