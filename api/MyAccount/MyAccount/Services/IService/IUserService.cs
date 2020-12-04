using MyAccount.DTO.User;
using MyAccount.Extensions.Pagination;
using System.Threading.Tasks;

namespace MyAccount.Services.IService
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(int id, UserDTO userDTO);
        Task<UserDTO> GetUserById(int id);
        Task DisableOrEnableUser(int id, bool enable = false);
        Task DeleteUser(int id);
        Task<PageResult<UserDTO>> GetUsersAsync(string filter, bool? enable, int count, int page);
    }
}