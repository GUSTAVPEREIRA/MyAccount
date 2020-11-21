using Microsoft.AspNetCore.Mvc;
using MyAccount.Model;
using MyAccount.Services.IService;

namespace MyAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IUserService userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            this.tokenService = tokenService;
            this.userService = userService;
        }

        [Route("Authenticate")]
        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] UserAthenticateDTO userDTO)
        {
            var user = new User();
            user.SetPassword(userDTO.password);
            user.Username = userDTO.username;
            var validUser = userService.GetUserForAuthenticate(user.Username, user.Password);

            if (validUser == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            var token = tokenService.GenerateToken(validUser);
            validUser.SetPassword("");

            return new OkObjectResult(new
            {
                token,
                tokenType = "Bearer Token",
                user = validUser,
            });
        }
    }
}