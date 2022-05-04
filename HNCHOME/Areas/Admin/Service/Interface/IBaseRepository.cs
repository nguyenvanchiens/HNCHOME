using System.Linq.Expressions;
using System.Reflection;

namespace HNCHOME.Service.Interface
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        int Insert(T obj);
        int Update(T obj);
        int Delete(object id);
        void Save();
        public IQueryable<T> Find(Expression<Func<T, bool>> expression);
    }
}
