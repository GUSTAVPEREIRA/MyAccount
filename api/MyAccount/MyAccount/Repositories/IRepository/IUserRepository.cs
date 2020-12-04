using MyAccount.Model;
using System.Threading.Tasks;

namespace MyAccount.Repositories.IRepository
{
    public interface IUserRepository
    {
        User GetUserForAuthenticate(string username, string password);
        Task<User> GetUserByID(int id);
    }
}