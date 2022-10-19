using System.Linq.Expressions;

namespace assignment1.Services
{
    public interface IBaseService<T, K> where T : class where K : class
    {
        T Create(K createModel);

        T? Get(Expression<Func<T, bool>> predicate, int id);

        T Update(int id, K entity);

        bool Delete(K entity);

        IEnumerable<T> GetAll(Expression<Func<K, bool>> predicate);
    }
}