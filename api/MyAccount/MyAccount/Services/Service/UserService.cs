using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAccount.DTO.User;
using MyAccount.Model;
using MyAccount.Repositories.IRepository;
using MyAccount.Services.IService;
using MyAccount.Utils.Exceptions;

namespace MyAccount.Services.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public UserService(ApplicationContext context, IMapper mapper, IUserRepository userRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
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

                userDTO = mapper.Map<User, UserDTO>(user);
                return userDTO;
            }
            catch (ApiExceptions ex)
            {
                throw new ApiExceptions(ex.StatusCode, ex.Message, ex);
            }
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await userRepository.GetUserByID(id);
            var userDTO = mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await userRepository.GetUserByID(id);

            try
            {
                if (user == null)
                {
                    throw new ApiExceptions(HttpStatusCode.NotFound, "O usuário não foi encontrado!");
                }

                user.Name = !string.IsNullOrEmpty(userDTO.Name) ? userDTO.Name : user.Name;

                if (!string.IsNullOrEmpty(userDTO.Password))
                {
                    user.SetPassword(userDTO.Password);
                }

                context.Add(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApiExceptions(HttpStatusCode.BadRequest, ex.Message);
            }

            userDTO = mapper.Map<User, UserDTO>(user);

            return userDTO;
        }
    }
}