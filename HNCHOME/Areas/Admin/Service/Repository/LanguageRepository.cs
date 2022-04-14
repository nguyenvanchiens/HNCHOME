namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
