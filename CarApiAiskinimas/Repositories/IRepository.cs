using System.Linq.Expressions;

namespace CarApiAiskinimas.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> All();
        T Get(int id);
        int Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        int Count();
        bool Exist(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    }
}
