using Company.API.Models.Domain;
using Company.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployee_DetailsRepository employee_DetailsRepository;

        public EmployeeDetailsController(IEmployee_DetailsRepository employee_DetailsRepository)
        {
            this.employee_DetailsRepository = employee_DetailsRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetEmployeeDetails()
        {
            var emp = await employee_DetailsRepository.GetDetails();

            return Ok(emp);
        }

        [HttpGet]
        [Route("{id:int}")]
          public async Task<IActionResult> GetDetailsById(int id)
          {
            var emp_details=await employee_DetailsRepository.GetById(id);
            if(emp_details != null)
            {
                return NotFound();
            }
            return Ok(emp_details);
          }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee_Details employee_Details)
        {
            var emp= await employee_DetailsRepository.AddEmp_Details(employee_Details);
            return Ok(emp);
        }
    }
}
