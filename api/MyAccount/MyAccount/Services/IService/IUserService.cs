using MyAccount.Model;

namespace MyAccount.Services.IService
{
    public interface IUserService
    {
        User GetUserForAuthenticate(string username, string password);
    }
}