using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAccount.Mapping;
using MyAccount.Model;

namespace MyAccount
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<User> TbUsers { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,11434;Database=MyAccount;Persist Security Info=True;MultipleActiveResultSets=true;User ID=SA;Password=gpereira@1");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);
            base.OnModelCreating(builder);
        }
    }
}
