using Microsoft.AspNet.Identity.EntityFramework;

namespace TenantManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //public System.Data.Entity.DbSet<TenantManagementSystem.Models.Department> Departments { get; set; }

        //public System.Data.Entity.DbSet<TenantManagementSystem.Models.Teacher> Teachers { get; set; }

        //public System.Data.Entity.DbSet<TenantManagementSystem.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<TenantManagementSystem.Models.Admin> Admins { get; set; }
        public System.Data.Entity.DbSet<TenantManagementSystem.Models.Company> Company { get; set; }

        public System.Data.Entity.DbSet<TenantManagementSystem.Models.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<TenantManagementSystem.Models.Property> Properties { get; set; }
    }
}