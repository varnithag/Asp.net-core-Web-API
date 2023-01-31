using Company.API.Data;
using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public class EmployeeRoleRepository : IEmployeeRoleRepository
    {
        private readonly NewCompanyDbContextcs _companyDbContextcs;
        public EmployeeRoleRepository(NewCompanyDbContextcs companyDbContextcs) {
            _companyDbContextcs = companyDbContextcs;
        
        }

        public async Task<EmployeeRoles> AddRoles(EmployeeRoles roles)
        {
            await _companyDbContextcs.AddAsync(roles);
            await _companyDbContextcs.SaveChangesAsync();
            return roles;
        }

        public async Task<EmployeeRoles> DeleteRole(string id)
        {
            var Role=await _companyDbContextcs.EmployeeRoles.FirstOrDefaultAsync(x=>x.Roleid==id);
            if (Role==null)
            {
                return null;
            }
            _companyDbContextcs.EmployeeRoles.Remove(Role);
            await _companyDbContextcs.SaveChangesAsync();
            return Role;
        }

        public async Task<IEnumerable<EmployeeRoles>> GetAll()
        {
            return await _companyDbContextcs.EmployeeRoles.ToListAsync();
        }

        public Task<IEnumerable<EmployeeRoles>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeRoles> GetById(string id)
        {
            
            var Role= await _companyDbContextcs.EmployeeRoles.FirstOrDefaultAsync(x=>x.Roleid==id);
            if (Role==null)
            {
                return null;
            }
            return Role;
        }
    }
}
