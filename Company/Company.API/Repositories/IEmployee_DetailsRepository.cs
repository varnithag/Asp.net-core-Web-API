using Company.API.Models.Domain;

namespace Company.API.Repositories
{
    public interface IEmployee_DetailsRepository
    {
        Task<IEnumerable<Employee_Details>> GetDetails();
        Task<Employee_Details> GetById(int id);

        Task<Employee_Details> AddEmp_Details(Employee_Details employee_Details);
    }
}
