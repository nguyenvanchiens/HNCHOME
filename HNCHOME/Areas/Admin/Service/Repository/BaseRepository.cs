﻿using HNCHOME.Service.Interface;

namespace HNCHOME.Service.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private HNCDbContext _context = null;
        private DbSet<T> table = null;
        public BaseRepository(HNCDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
