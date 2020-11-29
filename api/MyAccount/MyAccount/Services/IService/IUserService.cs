using MyAccount.DTO.User;
using MyAccount.Model;
using System.Threading.Tasks;

namespace MyAccount.Services.IService
{
    public interface IUserService
    {        
        Task<User> CreateUser(UserDTO userDTO);        
    }
}