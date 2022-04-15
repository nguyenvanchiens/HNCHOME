namespace HNCHOME.Areas.Admin.Service.Interface
{
    public interface IMenuRepository:IBaseRepository<Menu>
    {
        List<TreeNodeMenu> GetChildren(List<TreeNodeMenu> menus, Guid parentId);
        object GetParentNode();
    }
}
