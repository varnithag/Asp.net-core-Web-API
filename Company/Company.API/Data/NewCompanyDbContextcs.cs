using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Data
{
    public class NewCompanyDbContextcs:DbContext
    {
        public NewCompanyDbContextcs()
        {

        }
        public NewCompanyDbContextcs(DbContextOptions<NewCompanyDbContextcs> options):base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role> User_Roles { get; set; } 

       public DbSet<Employee_Details> Employee_Details { get; set; }
    }
}
