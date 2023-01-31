using Company.API.Models.Domain;
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
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await employeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var emp = await employeeRepository.AddEmp(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Empid }, emp);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult>DeleteEmployee(int id)
        {
            var emp = await employeeRepository.Delete(id);
            if (emp == null)
            {
                return NotFound();
            }           
            return Ok(emp);
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            //Update Employee using repository
            var emp = await employeeRepository.Update(id, employee);


            //If Null then NotFound
            if (emp == null)
            {
                return NotFound();
            }
            //Return Ok response
            return Ok(emp);
        }

    }
}
