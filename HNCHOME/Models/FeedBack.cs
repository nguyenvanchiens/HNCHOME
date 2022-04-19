namespace HNCHOME.Models
{
    public class FeedBack
    {
        public Guid FeedBackId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
