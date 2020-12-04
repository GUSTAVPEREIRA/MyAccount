using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAccount.DTO.User;
using MyAccount.Extensions.Pagination;
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

        public async Task DeleteUser(int id)
        {
            var user = await userRepository.GetUserByID(id);

            if (user == null)
            {
                throw new ApiExceptions(HttpStatusCode.NotFound, "Usuário não foi encontrado.");
            }

            try
            {
                context.Remove(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApiExceptions(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task DisableOrEnableUser(int id, bool enable = false)
        {
            var user = await userRepository.GetUserByID(id);

            if (user == null)
            {
                throw new ApiExceptions(HttpStatusCode.NotFound, "Usuário não foi encontrado.");
            }

            if (enable)
            {
                user.EnableUser();
            }
            else
            {
                user.DisableUser();
            }

            try
            {
                context.Add(user).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApiExceptions(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await userRepository.GetUserByID(id);
            var userDTO = mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public async Task<PageResult<UserDTO>> GetUsersAsync(string filter, bool? enable, int count, int page)
        {
            var users = await userRepository.GetUsersAsync(filter, enable, count, page);

            var usersDTO = new PageResult<UserDTO>
            {
                CurrentPage = users.CurrentPage,
                PageCount = users.PageCount,
                PageSize = users.PageSize,
                resultCount = users.resultCount,
                Results = mapper.Map<ICollection<User>, ICollection<UserDTO>>(users.Results),
                RowCount = users.RowCount
            };            

            return usersDTO;
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