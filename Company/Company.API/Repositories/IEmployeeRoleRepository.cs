using Company.API.Models.Domain;

namespace Company.API.Repositories
{
    public interface IEmployeeRoleRepository
    {
        Task<IEnumerable<EmployeeRoles>> GetAllRoles();
        Task<EmployeeRoles> GetById(string id);

        Task<EmployeeRoles> AddRoles(EmployeeRoles roles);
        Task<EmployeeRoles> DeleteRole(string id);
    }
}
