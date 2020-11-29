using Microsoft.AspNetCore.Mvc;
using MyAccount.Model;
using MyAccount.Repositories.IRepository;
using MyAccount.Services.IService;

namespace MyAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IUserRepository userRepository;

        public AuthController(ITokenService tokenService, IUserRepository userRepository)
        {
            this.tokenService = tokenService;
            this.userRepository = userRepository;
        }

        [Route("Authenticate")]
        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] UserAthenticateDTO userDTO)
        {
            var user = new User();
            user.SetPassword(userDTO.password);
            user.Username = userDTO.username;
            User validUser = userRepository.GetUserForAuthenticate(user.Username, user.Password);

            if (validUser == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            var token = tokenService.GenerateToken(validUser);

            return new OkObjectResult(new
            {
                token,
                tokenType = "Bearer Token",
                user = validUser,
            });
        }
    }
}