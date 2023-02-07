using Common.Entities;

namespace Common.Interfaces
{
    public interface IGenericRepositoryBasedService<T> : IGenericRepository<T> where T : Entity
    {
    }
}
