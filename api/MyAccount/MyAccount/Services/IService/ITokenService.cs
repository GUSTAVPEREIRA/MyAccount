using MyAccount.Model;

namespace MyAccount.Services.IService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}