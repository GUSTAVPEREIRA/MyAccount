using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MyAccount.DTO.User;
using MyAccount.Model;
using MyAccount.Services.IService;
using MyAccount.Utils.Exceptions;

namespace MyAccount.Services.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        public UserService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<User> CreateUser(UserDTO userDTO)
        {
            try
            {
                if (context.TbUsers.Where(w => w.Username == userDTO.Username).Any())
                {
                    throw new ApiExceptions(HttpStatusCode.BadRequest, "O usuário já está configurado no sistema.");
                }

                var user = mapper.Map<UserDTO, User>(userDTO);

                await context.TbUsers.AddAsync(user);
                context.SaveChanges();

                return user;
            }
            catch (ApiExceptions ex)
            {
                throw new ApiExceptions(ex.StatusCode, ex.Message, ex);
            }
        }
    }
}