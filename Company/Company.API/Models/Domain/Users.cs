using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.API.Models.Domain
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }
        
       
       
    }
}
