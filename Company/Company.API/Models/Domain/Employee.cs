using System.ComponentModel.DataAnnotations;

namespace Company.API.Models.Domain
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        public string? Empname { get; set; }
        public int Empage { get; set; }
        public int Empnumber { get; set; }
        public EmployeeRoles EmployeeRoles { get; set; }
    }
}
