using Company.API.Data;
using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly CompanyDbContextcs companyDbContextcs;

        public EmployeeRepository(CompanyDbContextcs companyDbContextcs)
        {
            this.companyDbContextcs = companyDbContextcs;
        }

        public async Task<IEnumerable<Employee>> GetAllEmp()
        {
            return await companyDbContextcs.Employees.ToListAsync();
        }
    }
}
