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
                //optionsBuilder.UseSqlServer("User ID=postgres;Password=postgres;Server=localhost;Port=5432; Database=ControleBancarioTestes; Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);
            base.OnModelCreating(builder);
        }
    }
}
