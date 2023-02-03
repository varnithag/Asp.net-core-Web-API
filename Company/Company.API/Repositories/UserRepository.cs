using Company.API.Data;
using Company.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NewCompanyDbContextcs newCompanyDbContextcs;

        public UserRepository(NewCompanyDbContextcs newCompanyDbContextcs)
        {
            this.newCompanyDbContextcs = newCompanyDbContextcs;
        }
        public async Task<Users> Authenticate(string username, string password)
        {
           var user = await newCompanyDbContextcs.Users
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() && x.Passwords == password);
           
            if(user == null)
            {
                return null;
            } 
            var userRoles= await newCompanyDbContextcs.User_Roles.Where(x=> x.UserId== user.Id).ToListAsync();
            
            if(userRoles.Any() )
            {
                user.Roles = new List<string>();
                foreach(var userRole in userRoles)
                {
                    var role = await newCompanyDbContextcs.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if(role != null)
                    {
                        user.Roles.Add(role.UserRoleName);
                    }
                }
            }
            user.Passwords = null;
            return user;
        }
    }
}
