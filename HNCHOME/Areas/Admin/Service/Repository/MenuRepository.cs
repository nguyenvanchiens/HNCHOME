using HNCHOME.Service.Repository;

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(HNCDbContext context) : base(context)
        {
        }
        public string checkDuplicate(Menu menu)
        {
            var result = "";
            var menus = _context.Menus.ToList();
            var checkUrl = menus.Where(x => x.Link == menu.Link && x.MenuId != menu.MenuId).FirstOrDefault();
            if (checkUrl != null)
            {
                result = "Link đã tồn tại";
            }
            return result;
        }

        public List<TreeNodeMenu> GetChildren(List<TreeNodeMenu> menus, Guid parentId)
        {
            return menus
                   .Where(c => c.ParentId == parentId)
                   .Select(c => new TreeNodeMenu { MenuId = c.MenuId, Title = c.Title, Link = c.Link, ParentId = c.ParentId, data = GetChildren(menus, c.MenuId) })
                   .ToList();
        }

        public object GetParentNode()
        {
            var menus = _context.Menus.Select(x => new TreeNodeMenu()
            {
                MenuId = x.MenuId,
                Title = x.Title,
                Link = x.Link,
                ParentId = x.ParentId
            }).ToList();
            List<TreeNodeMenu> result = new List<TreeNodeMenu>();
            result = menus.Where(c => c.ParentId == Guid.Empty)
                          .Select(c => new TreeNodeMenu() { MenuId = c.MenuId, Title = c.Title, ParentId = c.ParentId, Link = c.Link, data = GetChildren(menus, c.MenuId) })
                          .ToList();
            return result;
        }

        public override int Insert(Menu obj)
        {
            var result = checkDuplicate(obj);
            if (result != "")
            {
                throw new Exception(result);
            }
            return base.Insert(obj);
        }
    }
}
