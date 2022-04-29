namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class HomeControllerVM
    {
        public Employee EmployeeVM { get; set; }
        public List<EmployeeViewModel> ListEmployeeVM { get; set; }
        public List<Department> DepartmentList { get; set; }
    }
   
}
