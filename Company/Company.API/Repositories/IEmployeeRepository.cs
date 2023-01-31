using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmp();
        Task<Employee> GetById(int id);

        Task<Employee>AddEmp(Employee employee);

        Task<Employee>Delete(int id);

        Task<Employee> Update(int id,Employee employee);
    }
}
