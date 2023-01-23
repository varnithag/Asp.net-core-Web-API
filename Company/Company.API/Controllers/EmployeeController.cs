using Company.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emp = await employeeRepository.GetAllEmp();
            return Ok(emp);
        }
    }
}
