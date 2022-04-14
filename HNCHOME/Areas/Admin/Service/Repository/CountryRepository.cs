namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository

    {
        public CountryRepository(HNCDbContext context) : base(context)
        {
        }

        IEnumerable<Country> GetAll()
        {
            throw new NotImplementedException();
        }
        Country GetById(object id)
        {
            throw new NotImplementedException();
        }
        void Insert(Country obj)
        {
            throw new NotImplementedException();
        }
        void Update(Country obj)
        {
            throw new NotImplementedException();
        }
        void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        void Save()
        {
            throw new NotImplementedException();
        }

        void ICountryRepository.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
