using MyAccount.DTO.User;
using MyAccount.Model;
using System.Threading.Tasks;

namespace MyAccount.Services.IService
{
    public interface IUserService
    {
        User GetUserForAuthenticate(string username, string password);
        Task<User> CreateUser(UserDTO userDTO);
        Task<UserDTO> GetUserByID(int id);
    }
}