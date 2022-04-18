namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        IEnumerable<Employee> GetAllPaeging(string filter);
        string CheckDublicate(Employee employee);
    }
}
