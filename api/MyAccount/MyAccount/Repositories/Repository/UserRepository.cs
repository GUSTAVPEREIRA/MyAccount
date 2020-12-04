using MyAccount.Extensions.Pagination;
using MyAccount.Model;
using MyAccount.Repositories.IRepository;
using System;
using System.Collections.Generic;
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

        public async Task<PageResult<User>> GetUsersAsync(string filter, bool? enable, int count, int page)
        {
            IQueryable<User> query = context.TbUsers;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(w => w.Name.Contains(filter) || w.Username.Contains(filter));
            }

            if (int.TryParse(filter, out int id))
            {
                query = query.Where(w => w.Id == id);
            }

            if (enable.HasValue)
            {
                if (enable.Value)
                {
                    query = query.Where(w => w.DeletedAt == null);
                }
                else
                {
                    query = query.Where(w => w.DeletedAt != null);
                }
            }

            var users = await query.GetPageResultAsync(page, count);

            return users;
        }
    }
}