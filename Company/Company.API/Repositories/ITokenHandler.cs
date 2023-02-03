using Company.API.Models.Domain;

namespace Company.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(Users user);
    }
}
