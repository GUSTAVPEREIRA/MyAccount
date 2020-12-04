using MyAccount.DTO.User;
using System.Threading.Tasks;

namespace MyAccount.Services.IService
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(int id, UserDTO userDTO);
        Task<UserDTO> GetUserById(int id);
    }
}