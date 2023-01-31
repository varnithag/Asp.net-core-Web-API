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

        //Adds an Employee into the Employee table
        public async Task<Employee> AddEmp(Employee employee)
        {
            await companyDbContextcs.AddAsync(employee);
            await companyDbContextcs.SaveChangesAsync();
            return employee;
        }

       //Deleting Employee from the table
        public  async Task<Employee> Delete(int id)
        {
            //Find the employee with given wmployee id
            var emp = await companyDbContextcs.Employees.FirstOrDefaultAsync(x => x.Empid == id);
            
            //if employee with given employee id is not in the table returns null
            if (emp == null)
            {
                return null;
            }

            //if employee with given employee id id found, it is removed from the table
            companyDbContextcs.Employees.Remove(emp);

            //Saving the changes
            await companyDbContextcs.SaveChangesAsync();
            
            //Returning the deleted employee details
            return emp;
        }

        
        //Get details of all Employees
        public async Task<IEnumerable<Employee>> GetAllEmp()
        {
            return await companyDbContextcs.Employees.ToListAsync();
        }



        //Employee Details of given Employee id 
        public async Task<Employee> GetById(int id)
        {
           var emp=await companyDbContextcs.Employees.FirstOrDefaultAsync(x=>x.Empid==id);

            //if given employee id is not in table return null
            if(emp==null)
            {
                return null;
            }

            //if given employee id is in table send the employee details
            return emp;
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var emp=await companyDbContextcs.Employees.FirstOrDefaultAsync(x=>x.Empid==id);
            
            
            //if given employee id is not in table return null
            if (emp==null)
            {
                return null;
            }

            //Updating the old values with new values
            emp.Empname=employee.Empname;
            emp.Empage = employee.Empage;
            emp.Empnumber = employee.Empnumber;
            emp.Emproleid = employee.Emproleid;

            await companyDbContextcs.SaveChangesAsync();
            return emp;
            
            
        }
    }
}
