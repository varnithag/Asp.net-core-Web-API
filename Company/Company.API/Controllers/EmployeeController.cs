using Company.API.Models.Domain;
using Company.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        //Get All Employee Details
        [HttpGet]
        [Authorize(Roles ="read")]

        public async Task<IActionResult> GetAllEmployees()
        {
            //Get all employee details using repository
            var emp = await employeeRepository.GetAllEmp();

            //return Ok response
            return Ok(emp);
        }


        //Get Employee by specifing id
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetEmployeeById")]
        [Authorize(Roles = "read")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            //get employee details by using repository
            var emp = await employeeRepository.GetById(id);
            
            //if given id is not found in database, sends 404not Found response
            if (emp == null)
            {
                return NotFound();
            }

            //if given id exists sends 200 Ok response
            return Ok(emp);
        }

        //Add new Employee into the table
        [HttpPost]
        [Authorize(Roles = "write")]
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


        //Delete a Employee from table
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "write")]
        public async Task<IActionResult>DeleteEmployee(int id)
        {
            var emp = await employeeRepository.Delete(id);
            if (emp == null)
            {
                return NotFound();
            }           
            return Ok(emp);
            
        }

        //Updating Employee Details of given employee Id using Post method
        [HttpPost]
        [Route("{id:int}")]
        [Authorize(Roles = "write")]
        public async Task<IActionResult> UpdateEmployeeUsingPost([FromRoute] int id, [FromBody] Employee employee)
        {
            // Update Employee using repository
            var emp = await employeeRepository.Update(id, employee);


            //If Null then NotFound
            if (emp == null)
            {
                return NotFound();
            }
            //Return Ok response
            return Ok(emp);

        }


        //Updating Employee details of given Employee id using Put method
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "write")]
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
