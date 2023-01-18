using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Data
{
    public class CompanyDbContextcs:DbContext
    {
        public CompanyDbContextcs(DbContextOptions<CompanyDbContextcs> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
    }
}
