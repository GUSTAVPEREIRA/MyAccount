using Microsoft.EntityFrameworkCore;

namespace MyAccount.Mapping
{
    public interface IMapping
    {
        public void Mapping(ref ModelBuilder builder);
    }
}