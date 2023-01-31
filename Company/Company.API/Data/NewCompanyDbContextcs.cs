using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Data
{
    public class NewCompanyDbContextcs:DbContext
    {
        public NewCompanyDbContextcs(DbContextOptions<NewCompanyDbContextcs> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
    }
}
