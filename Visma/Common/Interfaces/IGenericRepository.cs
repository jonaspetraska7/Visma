using Common.Entities;
using System.Linq.Expressions;

namespace Common.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        int Add(T entity);
        int Remove(T entity);
    }
}
