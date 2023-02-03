using System.ComponentModel.DataAnnotations;

namespace Company.API.Models.Domain
{
    public class User_Role
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users user { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }

    }
}
