using MyAccount;
using MyAccount.DTO.User;
using MyAccount.Model;
using MyAccount.Repositories.IRepository;
using MyAccount.Services.Service;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyAccountTests
{
    public class UserTest
    {
        private readonly ApplicationContext context;
        private readonly UserService userService;        
        private readonly IUserRepository userRepository;        

        public UserTest()
        {
            context = ContextTest.GetContext();            
            userService = new UserService(context, ContextTest.GetMapping(), userRepository);
        }       

        [Fact(DisplayName = "When i enter password, i want it to be encrypted.")]
        public void IWishPasswordSetEncripted()
        {
            string password = "123456";

            User user = new User();
            user.SetPassword(password);

            Assert.NotEqual(password, user.Password);
        }

        [Theory(DisplayName = "When i enter a new user, i want created corretly user.")]
        [InlineData("gpereira", "123456")]
        public async Task IWishCreateAnUserAsync(string username, string password)
        {
            var userDTO = new UserDTO
            {
                Username = username,
                Password = password
            };

            var user = await userService.CreateUser(userDTO);

            Assert.NotNull(user);
            Assert.NotEqual(user.CreatedAt, new DateTime());
            Assert.NotEqual(user.Password, password);            
        }
    }
}