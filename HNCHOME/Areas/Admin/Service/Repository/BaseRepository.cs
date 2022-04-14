using HNCHOME.Service.Interface;
using System.Reflection;

namespace HNCHOME.Service.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected HNCDbContext _context = null;
        private DbSet<T> table = null;
        public BaseRepository(HNCDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public int Delete(object id)
        {
            T existing = GetById(id);
            var result = table.Remove(existing);
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.Success;
            }
            return (int)StatusCodeRespon.BadRequest;

        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public int Insert(T obj)
        {
            var result = table.Add(obj);
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.UpdateSuccess;
            }
            return (int)StatusCodeRespon.BadRequest;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual int Update(T obj)
        {
            var result = table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.UpdateSuccess;
            }
            return (int)StatusCodeRespon.BadRequest;
        }
    }
}
