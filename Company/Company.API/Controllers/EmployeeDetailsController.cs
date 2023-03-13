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

      /*  [HttpGet]
        [Route("{int:id}")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var emp_details=await employee_DetailsRepository.Ge
        }*/
    }
}
