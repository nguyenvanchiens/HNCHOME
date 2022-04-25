namespace HNCHOME.Common
{
    public class Constants
    {
        public static class HomeComponent
        {
            public const string CountryComponent = "Country";
            public const string BranchComponent = "Branch";
        }
        public static class PartialViewName
        {
            public const string CHILDREN_MENU_PARTIAL = "_childrenMenu";
        }
        public static partial class FileExtension
        {
            public static List<string> imgExtension = new List<string>() {".jpg",".png", ".jpeg", ".gif", ".tiff", ".raw", "svg" };
        }
    }
}
