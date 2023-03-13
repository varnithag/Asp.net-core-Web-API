using Microsoft.EntityFrameworkCore;

namespace Company.API.Models.Domain
{
    [Keyless]
    public class Employee_Details
    {
        public int Empid { get; set; }
        public string? Empname { get; set; }
        public int Empage { get; set; }
        public string Empnumber { get; set; }
        public string? Roleid { get; set; }
        public string? Rolename { get; set; }
    }
}
