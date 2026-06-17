using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data.Entities.User;

namespace TechMart_E_Commerce_Management_System.Data.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(x => x.UserId)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                .IsUnique
                ();
            builder.Property(x => x.PasswordHash)
                .IsRequired();
            builder.Property(x => x.ProfileImage)
                .HasMaxLength(300);
            builder.Property(x => x.Role)
                .IsRequired();
            builder.Property(x => x.IsEmailVerified)
                .HasDefaultValue(false);
            builder.Property(x => x.IsActive)
                .HasDefaultValue
                (true);
            builder.Property(x => x.CreatedAt)
                .IsRequired();

        }
    }
}
