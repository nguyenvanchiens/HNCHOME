namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        IEnumerable<Country> GetAllPaeging(string filter);
    }
}
