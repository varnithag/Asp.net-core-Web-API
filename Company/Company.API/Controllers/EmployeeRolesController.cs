/*using Company.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : Controller
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        public EmployeeRolesController(IEmployeeRoleRepository employeeRoleRepository) {
            _employeeRoleRepository = employeeRoleRepository;
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles() {
            var roles=await _employeeRoleRepository.GetAllRoles();
            return Ok(roles);
        }
        [HttpGet]
        [Route("{id:string}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var roles= await _employeeRoleRepository.GetById(id);
            if (roles == null)
            {
                return NotFound();
            }
          return Ok(roles);
        }
        
        

    }
}
*/