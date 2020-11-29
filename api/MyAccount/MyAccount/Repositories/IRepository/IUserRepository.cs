using MyAccount.DTO.User;
using MyAccount.Model;
using System.Threading.Tasks;

namespace MyAccount.Repositories.IRepository
{
    public interface IUserRepository
    {
        User GetUserForAuthenticate(string username, string password);
        Task<UserDTO> GetUserByID(int id);
    }
}