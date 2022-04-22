namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string? EmployeeName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? DepartmentName { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
