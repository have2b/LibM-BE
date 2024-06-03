using System.Linq.Expressions;
using Core.Contracts;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T>(ApplicationDbContext context) : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context = context;

        public IQueryable<T> GetAll() => _context.Set<T>();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}