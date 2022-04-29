namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(HNCDbContext context) : base(context)
        {
        }
        public override IEnumerable<Country> GetAll()
        {
            var pro = new Branch();
            var contry = base.GetAll();
            foreach (var c in contry)
            {
                c.Branches = new List<Branch>();
            }
            return base.GetAll();
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
