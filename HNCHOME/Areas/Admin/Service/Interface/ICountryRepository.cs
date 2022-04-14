namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        IEnumerable<Country> GetAll();
        Country GetById(object id);
        void Insert(Country obj);
        void Update(Country obj);
        void Delete(Guid id);
        void Save();
    }
}
