using AutoMapper;
using MyAccount.DTO.User;
using MyAccount.Model;
using MyAccount.Repositories.IRepository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccount.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
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

                user.SetPassword("");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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