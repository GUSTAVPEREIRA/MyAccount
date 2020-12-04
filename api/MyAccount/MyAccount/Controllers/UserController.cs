using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAccount.DTO.User;
using MyAccount.Extensions.Pagination;
using MyAccount.Services.IService;
using System.Threading.Tasks;

namespace MyAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{count:int?}/{page:int?}")]
        [Authorize]
        public async Task<ActionResult<PageResult<UserDTO>>> GetListUsersAsync([FromQuery] UserSearchDTO search, int count = 30, int page = 1)
        {
            var result = await userService.GetUsersAsync(search.filter, search.enable, count, page);

            return new OkObjectResult(new
            {
                result
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetAsync(int id)
        {
            var user = await userService.GetUserById(id);

            return new OkObjectResult(new
            {
                usuario = user
            });
        }

        [HttpPost]
        [Authorize]
        public ActionResult<dynamic> Post([FromBody] UserDTO dto)
        {
            var user = userService.CreateUser(dto);

            return new OkObjectResult(new
            {
                usuario = user,
                message = "Usuário criado com sucesso!"
            });
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<dynamic> Put(int id, [FromBody] UserDTO dto)
        {
            var user = userService.UpdateUser(id, dto);

            return new OkObjectResult(new
            {
                usuario = user,
                message = "Usuário foi alterado!"
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            await userService.DeleteUser(id);

            return new OkObjectResult(new
            {
                message = "Usuário foi deletado."
            });
        }

        [HttpPut("disable/{id}/{enable}")]
        public async Task<ActionResult<dynamic>> DisableAsync(int id, bool enable = false)
        {
            await userService.DisableOrEnableUser(id, enable);
            var user = await userService.GetUserById(id);
            var tipo = enable ? "ativado" : "desativado";

            return new OkObjectResult(new
            {
                usuario = user,
                message = $"Usuário foi {tipo}"
            });
        }
    }
}