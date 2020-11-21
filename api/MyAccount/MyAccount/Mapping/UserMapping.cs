using System;
using Microsoft.EntityFrameworkCore;
using MyAccount.Model;

namespace MyAccount.Mapping
{
    public class UserMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(k => k.Id);
            builder.Entity<User>().Property(p => p.Username).HasMaxLength(30).IsRequired(true);
            builder.Entity<User>().HasIndex(p => p.Username).IsUnique(true);
            builder.Entity<User>().Property(p => p.Password).IsRequired(true).HasMaxLength(100);
            builder.Entity<User>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<User>().Property(p => p.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<User>().Property(p => p.DeletedAt).HasDefaultValue(new Nullable<DateTime>());
        }
    }
}