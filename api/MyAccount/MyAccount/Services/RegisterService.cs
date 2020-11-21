using Microsoft.Extensions.DependencyInjection;
using MyAccount.Services.IService;
using MyAccount.Services.Service;

namespace MyAccount.Services
{
    public class RegisterService
    {
        public void Register(ref IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}