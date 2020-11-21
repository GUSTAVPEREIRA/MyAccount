using System;
using System.Linq;
using MyAccount.Model;
using MyAccount.Services.IService;

namespace MyAccount.Services.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;

        public UserService(ApplicationContext context)
        {
            this.context = context;
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
    }
}