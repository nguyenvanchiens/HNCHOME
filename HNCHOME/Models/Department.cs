using HNCHOME.Attr;

namespace HNCHOME.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        [CheckDuplicate]
        public string DepartmentCode{ get; set; }
        [NotEmpty]
        public string? DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
