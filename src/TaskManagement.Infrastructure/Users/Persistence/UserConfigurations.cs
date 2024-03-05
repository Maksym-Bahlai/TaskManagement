using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskManagement.Domain.Users;

namespace TaskManagement.Infrastructure.Users.Persistence;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.UserName).IsUnique();

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.Email).IsRequired();

        builder.Property(u => u.LastName).IsRequired();

        builder.Property(u => u.FirstName).IsRequired();

        builder.HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);
    }
}