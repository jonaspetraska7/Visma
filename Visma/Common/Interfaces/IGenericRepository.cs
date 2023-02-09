using Common.Entities;
using System.Linq.Expressions;

namespace Common.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Guid Add(T entity);
        int Update(T entity);
        int Remove(Guid id);
    }
}
