using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAccount;
using MyAccount.MappingDTO;

namespace MyAccountTests
{
    public static class ContextTest
    {
        public static ApplicationContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("MyAccountTests").Options;
            var context = new ApplicationContext(options);
            return context;
        }

        public static IMapper GetMapping()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingDTO());
            });

            return mockMapper.CreateMapper();
        }
    }
}