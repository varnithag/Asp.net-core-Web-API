using Company.API.Models.Domain;

namespace Company.API.Repositories
{
    public interface IUserRepository
    {
        Task<Users> Authenticate(string username, string password);
    }
}
