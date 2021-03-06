namespace HNCHOME.Models
{
    public class FeedBack
    {
        public Guid FeedBackId { get; set; }
        [Column(TypeName ="NVARCHAR(50)")]
        [Required(ErrorMessage = "Please enter your full name")]
        public string? Name { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        [Required(ErrorMessage = "Please enter email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter the phone number")]
        [Column(TypeName = "NVARCHAR(20)")]
        public string? Phone { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        [Required(ErrorMessage = "Please enter the content")]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
