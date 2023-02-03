using System.ComponentModel.DataAnnotations;

namespace Company.API.Models.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string UserRoleName { get; set; }

       
    }
}
