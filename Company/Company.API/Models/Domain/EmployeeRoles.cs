using System.ComponentModel.DataAnnotations;

namespace Company.API.Models.Domain
{
    public class EmployeeRoles
    {
        [Key]
        public string? Roleid { get; set; }
        public string? Rolename { get; set; }

        
    }
}
