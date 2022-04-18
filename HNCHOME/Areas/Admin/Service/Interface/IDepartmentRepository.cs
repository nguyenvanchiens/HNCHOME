
namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
        IEnumerable<Department> GetAllPaeging(string filter);
        string checkDuplicate(Department department);
    }
}
