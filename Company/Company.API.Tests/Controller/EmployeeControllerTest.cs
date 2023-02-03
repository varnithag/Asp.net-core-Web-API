using Company.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.Tests.Controller
{
    public class EmployeeControllerTest
    {
        public EmployeeControllerTest()
        {
            _employeeRepository = A.Fake<IEmployeeRepository>();
        }
    }
}
