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

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
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

        public async Task<User> GetUserByID(int id)
        {
            var user = await context.TbUsers.FindAsync(id);

            return user;
        }
    }
}