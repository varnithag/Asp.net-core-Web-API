using System.ComponentModel.DataAnnotations;

namespace Company.API.Models.Domain
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        public string? Empname { get; set; }
        public int Empage { get; set; }
        public string Empnumber { get; set; }

        public string Emproleid { get; set; }
        
    }
}
