using Microsoft.AspNetCore.Mvc;
using MyAccount.DTO.User;
using MyAccount.Services.IService;
using MyAccount.Utils.Exceptions;
using System;

namespace MyAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstConfigurationsController : ControllerBase
    {

        private readonly IUserService userService;

        public FirstConfigurationsController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        public ActionResult<dynamic> CreateFirstUser()
        {
            try
            {
                //Create default user, for new system.
                UserDTO userDTO = new UserDTO();
                userDTO.Name = "Administrador";
                userDTO.Username = "admin";
                userDTO.Password = "admin";
                userDTO.CreatedAt = DateTime.UtcNow.Date;
                userDTO.UpdatedAt = DateTime.UtcNow.Date;

                var user = userService.CreateUser(userDTO);

                return new OkObjectResult(new
                {
                    user,
                    message = "Configurações iniciais realizadas com sucesso."
                });
            }
            catch (ApiExceptions ex)
            {
                return new BadRequestObjectResult(new
                {
                    message = ex.Message,
                    ex.StatusCode
                });
            }
        }
    }
}