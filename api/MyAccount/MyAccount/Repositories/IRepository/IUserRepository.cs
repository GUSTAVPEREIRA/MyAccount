using MyAccount.Extensions.Pagination;
using MyAccount.Model;
using System.Threading.Tasks;

namespace MyAccount.Repositories.IRepository
{
    public interface IUserRepository
    {
        User GetUserForAuthenticate(string username, string password);
        Task<User> GetUserByID(int id);
        Task<PageResult<User>> GetUsersAsync(string filter, bool? enable, int count, int page);
    }
}