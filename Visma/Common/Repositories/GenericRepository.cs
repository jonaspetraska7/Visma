using Common.Data;
using Common.Entities;
using Common.Interfaces;
using LinqToDB;
using System.Linq.Expressions;

namespace Common.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly VismaDataConnection _context;
        public GenericRepository(VismaDataConnection context)
        {
            _context = context;
        }
        public virtual T? GetById(Guid id)
        {
            return _context.GetTable<T>().FirstOrDefault(x => x.Id == id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _context.GetTable<T>().ToList();
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.GetTable<T>().Where(expression);
        }
        public virtual Guid Add(T entity)
        {
            entity.Id = Guid.NewGuid();

            _context.Insert(entity);

            return entity.Id;
        }
        public virtual int Update(T entity)
        {
            return _context.Update(entity);
        }
        public virtual int Remove(Guid id)
        {
            return _context.GetTable<T>().Where(x => x.Id == id).Delete();
        }
    }
}
