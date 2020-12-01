using Microsoft.AspNetCore.Mvc;
using MyAccount.DTO.User;
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

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            return "";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetAsync(int id)
        {
            var user = await userService.GetUserById(id);

            return new OkObjectResult(new
            {
                usuario = user
            });
        }

        [HttpPost]
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
        public void Delete(int id)
        {

        }

        [Route("/Disable/{id}")]
        [HttpPut]
        public void Disable(int id)
        {

        }
    }
}
