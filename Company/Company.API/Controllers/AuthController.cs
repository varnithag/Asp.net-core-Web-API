using Company.API.Models.Domain;
using Company.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        public IUserRepository UserRepository { get; }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            //Check if user is authenticated
            //Ckeck username and password
            var isAuthenticated = await userRepository.Authenticate(loginRequest.Username, loginRequest.Password);
            if (isAuthenticated != null)
            {
                //generate a JWT token
               var token= await tokenHandler.CreateToken(isAuthenticated);
                return Ok(token);

            }
            return BadRequest("Invalid credintials");
        }
    }
}
