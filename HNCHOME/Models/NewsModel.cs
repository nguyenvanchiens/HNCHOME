namespace HNCHOME.Models
{
    public class NewsModel:BaseClass
    {
        [Key]
        public Guid NewsId { get; set; }
        public string Title { get; set; }
        public string Content{ get; set; }
        public string ImgUrl { get; set; }

    }
}
