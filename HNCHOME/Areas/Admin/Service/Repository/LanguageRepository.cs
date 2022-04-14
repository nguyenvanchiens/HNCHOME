namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(HNCDbContext context) : base(context)
        {
        }

        public int UpdateLanguage(Language language)
        {
            var entity = GetById(language.LanguageId);
            entity.Name = language.Name;
            entity.Image = language.Image;
            entity.SortOrder = language.SortOrder;
            var result = _context.Languages.Update(entity);
            if (result != null)
            {
                Save();
                return (int)StatusCodeRespon.UpdateSuccess;
            }
            return (int)StatusCodeRespon.BadRequest;
        }

    }
}
