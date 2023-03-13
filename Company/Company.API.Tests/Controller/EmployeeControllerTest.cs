using Company.API.Controllers;
using Company.API.Models.Domain;
using Company.API.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.Tests.Controller
{
    public class EmployeeControllerTest
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeControllerTest()
        {
            _employeeRepository = A.Fake<IEmployeeRepository>();
        }

        [Fact]
        public async Task EmployeeController_GetAllEmployee_ReturnsOk()
        {
            //Arrange
            var emp = A.Fake<IEnumerable<Employee>>();
            var controller = new EmployeeController(_employeeRepository);

            //Act
            var result = await controller.GetAllEmployees();

            //Assert

            Assert.IsType<OkObjectResult>(result);
            //result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task EmployeeController_GetEmployeeById_Returns_NotFound_IfGivenIdHasNoEntryInDatabase()
        {

            //Arrange
            int Id = 1;
            var mockrepo = new Mock<IEmployeeRepository>();
            mockrepo.Setup(repo => repo.GetById(Id)).ReturnsAsync((Employee)null);
            var controller = new EmployeeController(mockrepo.Object);

            //Act
            var result = await controller.GetEmployeeById(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);



        }

        [Fact]
        public async Task EmployeeController_GetEmployeeById_ReturnsOk()
        {
            int Id = 1;
            var emp = A.Fake<Employee>();
            A.CallTo(() => _employeeRepository.GetById(Id)).Returns(emp);

            var controller = new EmployeeController(_employeeRepository);

            //Act
            var result = await controller.GetEmployeeById(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task EmployeeController_AddEmployee_ReturnsCreatedResponse()
        {
            //Arrange
            var emp = new Employee() { Empid = 1, Empname = "var", Empage = 22, Empnumber = "9576787898", Emproleid = "R00" };

            var controller = new EmployeeController(_employeeRepository);


            //Act
            var result = await controller.AddEmployee(emp);


            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task EmployeeController_AddEmployee_ReturnsBadRequest_IfNoDataIsEntered()
        {
            //Arrange
            var emp = new Employee() {};
            emp = null;
            var controller = new EmployeeController(_employeeRepository);
            controller.ModelState.AddModelError(nameof(emp), "Entered data cannot be null");
            

            //Act
            var result = await controller.AddEmployee(emp);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task EmployeeController_DeleteEmployee_ReturnsNotFoundIfFivenIdHasNoEntry()
        {
            //Arrange
            int id = 1;
            var mockrepo = new Mock<IEmployeeRepository>();
            mockrepo.Setup(repo => repo.GetById(id)).ReturnsAsync((Employee)null);
            var controller = new EmployeeController(mockrepo.Object);

            //Act
            var result= await controller.DeleteEmployee(id);
            
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EmployeeController_DeleteEmployee_ReturnsOk_IfGivenIdHasAnEntryAndDeletedSuccessfully()
        {
            //Arrange
            int id= 1;
            var emp=A.Fake<Employee>();
            var controller = new EmployeeController(_employeeRepository);


            //Act
            var result= await controller.DeleteEmployee(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
