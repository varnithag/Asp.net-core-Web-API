using Company.API.Data;
using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly NewCompanyDbContextcs companyDbContextcs;

        public EmployeeRepository(NewCompanyDbContextcs companyDbContextcs)
        {
            this.companyDbContextcs = companyDbContextcs;
        }

        public async Task<Employee> AddEmp(Employee employee)
        {
            await companyDbContextcs.AddAsync(employee);
            await companyDbContextcs.SaveChangesAsync();
            return employee;
        }

        public  async Task<Employee> Delete(int id)
        {

            var emp = await companyDbContextcs.Employees.FirstOrDefaultAsync(x => x.Empid == id);
            if (emp == null)
            {
                return null;
            }
            companyDbContextcs.Employees.Remove(emp);
            await companyDbContextcs.SaveChangesAsync();
            return emp;
        }

        public async Task<IEnumerable<Employee>> GetAllEmp()
        {
            return await companyDbContextcs.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
           return await companyDbContextcs.Employees.FirstOrDefaultAsync(x=>x.Empid==id);
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var emp=await companyDbContextcs.Employees.FirstOrDefaultAsync(x=>x.Empid==id);
            if(emp==null)
            {
                return null;
            }
            emp.Empname=employee.Empname;
            emp.Empage = employee.Empage;
            emp.Empnumber = employee.Empnumber;
            emp.Emproleid = employee.Emproleid;

            await companyDbContextcs.SaveChangesAsync();
            return emp;
            
            
        }
    }
}
