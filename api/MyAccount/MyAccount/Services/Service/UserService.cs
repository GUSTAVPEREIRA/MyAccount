using System;
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

        public User GetUserForAuthenticate(string username, string password)
        {
            try
            {
                var user = context.TbUsers.Where(w => w.Username == username && w.Password == password)
                    .FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<UserDTO> GetUserByID(int id)
        {
            var user = await context.TbUsers.FindAsync(id);

            var userDTO = mapper.Map<User, UserDTO>(user);

            return userDTO;
        }
    }
}