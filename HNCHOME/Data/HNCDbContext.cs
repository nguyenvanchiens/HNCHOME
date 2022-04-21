using Microsoft.EntityFrameworkCore;

namespace HNCHOME.Data
{
    public class HNCDbContext : DbContext
    {
        public HNCDbContext(DbContextOptions<HNCDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceInfo> ServiceInfos { get; set; }
        public DbSet<CustomerServiceRegistration> customerServiceRegistrations { get; set; }
    }
}
