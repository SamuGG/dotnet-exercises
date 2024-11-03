using System.Linq.Expressions;
using Game.Common.Domain.Entities;

namespace Game.Common.Application.Common.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> FindOneAsync(Guid id);
    Task<T> FindOneAsync(Expression<Func<T, bool>> filter);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> FindAllAsync(Expression<Func<T, bool>> filter);
    Task AddNewAsync(T entity);
    Task<T> FindOneAndReplaceAsync(T entity);
    Task<T> FindOneAndDeleteAsync(Guid id);
}