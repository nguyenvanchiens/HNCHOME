namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(HNCDbContext context) : base(context)
        {
        }

        public IEnumerable<Country> GetAllPaeging(string filter)
        {
            IEnumerable<Country> result = new List<Country>();
            if (filter != null)
            {
                result = _context.Countries.Where(x => x.CountryId.ToString().Contains(filter) || x.CountryName.Contains(filter) || x.Description.Contains(filter))
                    .ToList();
            }
            else
            {
                result = _context.Countries.ToList();
            }
            return result;
        }
    }
}
