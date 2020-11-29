using Microsoft.Extensions.DependencyInjection;
using MyAccount.Repositories.IRepository;
using MyAccount.Repositories.Repository;

namespace MyAccount.Repositories
{
    public class RegistryRepositories
    {
        public void Register(ref IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRepository, UserRepository>();            
        }
    }
}
