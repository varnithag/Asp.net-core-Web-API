/*using Company.API.Models.Domain;
using Company.API.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "write")]
        public async Task<IActionResult> GetAll() {
            var roles=await _employeeRoleRepository.GetAllRoles();
            return Ok(roles);
        }




        [HttpGet]
        [Route("{id}")]
        [ActionName("GetRoleById")]
        [Authorize(Roles = "write")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var roles= await _employeeRoleRepository.GetById(id);
            if (roles == null)
            {
                return NotFound();
            }
          return Ok(roles);
        }


        //Add new Role into the table
        [HttpPost]

        [Authorize(Roles = "write")]
        public async Task<IActionResult> AddEmployee(EmployeeRoles role)
        {

            //Using repository to add the given role details
            var Emprole = await _employeeRoleRepository.AddRoles(role);

            //if role details are added successfully sends the 201 created response
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Roleid }, Emprole);

        }

        //Delete a Role from table
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "write")]
        public async Task<IActionResult> DeleteEmployeeRole(string id)
        {
            var Emprole = await _employeeRoleRepository.DeleteRole(id);
            if (Emprole == null)
            {
                return NotFound();
            }
            return Ok(Emprole);

        }



        


    }
}
*/