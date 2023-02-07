using Common.Entities;
using Common.Interfaces;
using System.Linq.Expressions;

namespace Common.Services
{
    public class GenericRepositoryBasedService<T> : IGenericRepositoryBasedService<T> where T : Entity
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericRepositoryBasedService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public int Add(T entity) => _genericRepository.Add(entity);

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression) => _genericRepository.Find(expression);

        public IEnumerable<T> GetAll() => _genericRepository.GetAll();

        public T GetById(Guid id) => _genericRepository.GetById(id);

        public int Remove(T entity) => _genericRepository.Remove(entity);
    }
}
