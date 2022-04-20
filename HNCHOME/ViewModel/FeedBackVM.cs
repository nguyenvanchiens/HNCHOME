namespace HNCHOME.ViewModel
{
    public class FeedBackVM
    {
        public Guid FeedBackId { get; set; }
        [Required(ErrorMessage = "Please enter your full name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter the phone number")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Please enter the content")]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isError { get; set; }
    }
}
