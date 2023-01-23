using Company.API.Models.Domain;

namespace Company.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmp();
    }
}
