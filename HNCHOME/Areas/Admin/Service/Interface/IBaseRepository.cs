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
    }
}
