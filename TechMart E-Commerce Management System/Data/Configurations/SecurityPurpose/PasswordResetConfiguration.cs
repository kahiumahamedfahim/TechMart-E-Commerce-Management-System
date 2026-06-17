using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart_E_Commerce_Management_System.Data.Entities.User;

namespace TechMart_E_Commerce_Management_System.Data.Configurations.SecurityPurpose
{
    public class PasswordResetConfiguration :
        IEntityTypeConfiguration<PasswordResetCode>
    {
        public void Configure(EntityTypeBuilder<PasswordResetCode> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ResetCode)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.ExpiryTime)
                .IsRequired();
            builder.Property(x => x.IsUsed)
                .HasDefaultValue(false);
            builder.HasOne(x => x.User)
                .WithMany(x => x.PasswordResetCodes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
