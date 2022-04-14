namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface ILanguageRepository:IBaseRepository<Language>
    {
        int UpdateLanguage(Language language);
    }
}
