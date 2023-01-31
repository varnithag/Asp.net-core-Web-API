using Company.API.Models.Domain;
using Company.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            //Validate the Request
            if (!ValidateAddEmployee(employee))
            {
                return BadRequest(ModelState);
            }
            
            
            //Using repository to add the given employee details
            var emp = await employeeRepository.AddEmp(employee);

            //if employee details are added successfully sends the 201 created response
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

        #region Private methods

        private bool ValidateAddEmployee(Employee employee)
        {
            //if entered data is null, shows error message
            if (employee == null)
            {
                ModelState.AddModelError(nameof(employee), "Entered data cannot be null");
                return false;
            }

            //if Empname is null, shows error message
            if(string.IsNullOrWhiteSpace(employee.Empname))
            {
                ModelState.AddModelError(nameof(employee.Empname), "name cannot be null or empty or whitespace");
            }

            //if Empage is less than or equal to zero, shows error message
            if (employee.Empage <= 0)
            {
                ModelState.AddModelError(nameof(employee.Empage), "age cannot be zero or less than zero ");
            }

            //if Empnumber is null, shows error message
            if (string.IsNullOrWhiteSpace(employee.Empnumber))
            {
                ModelState.AddModelError(nameof(employee.Empnumber), "number cannot be null or empty or whitespace");
            }

            //if Empnumber is not a 10 digit number,shows error message
            if (employee.Empnumber.Length != 10)
            {
                ModelState.AddModelError(nameof(employee.Empnumber), "number must contain 10 digits");
            }

            //if Emproleid is null, shows error message 
            if (string.IsNullOrWhiteSpace(employee.Emproleid))
            {
                ModelState.AddModelError(nameof(employee.Emproleid), "Employee Role Id cannot be null or empty or whitespace");
            }

            //if any of the above error has occured then return false
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
#endregion

    }
}
