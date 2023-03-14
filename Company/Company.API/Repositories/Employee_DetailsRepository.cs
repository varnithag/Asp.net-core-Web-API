using Company.API.Data;
using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public class Employee_DetailsRepository : IEmployee_DetailsRepository
    {
        private readonly NewCompanyDbContextcs newCompanyDbContextcs;

        public Employee_DetailsRepository(NewCompanyDbContextcs newCompanyDbContextcs)
        {
            this.newCompanyDbContextcs = newCompanyDbContextcs;
        }

        public async Task<Employee_Details> AddEmp_Details(Employee_Details employee_Details)
        {
            string StoredProc = "exec Sp_insert" +
                "EmpId= " + employee_Details.Empid + "," +
                "Empname= '" + employee_Details.Empname + "'," +
                "Empage=" + employee_Details.Empage + "," +
                "Empnumber= '" + employee_Details.Empnumber + "'," +
                "Roleid='" + employee_Details.Roleid + "'," +
                "Rolename='" + employee_Details.Rolename + "'";

            var value = newCompanyDbContextcs.Employee_Details.FromSqlRaw(StoredProc);
            return (Employee_Details)value;


        }

        public async Task<Employee_Details> GetById(int id)
        {
            string StoredProc = "exec Sp_GetEmployeeDeatilsById"+"Empid="+id;
            var value = newCompanyDbContextcs.Employee_Details.FromSqlRaw(StoredProc);

            if ((Employee_Details)value == null)
            {
                return null;
            }

            return (Employee_Details)value;
        }

        public async  Task<IEnumerable<Employee_Details>> GetDetails()
        {
            string StoredProc = "exec Sp_GetEmployeeDeatils";
            return await newCompanyDbContextcs.Employee_Details.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}
