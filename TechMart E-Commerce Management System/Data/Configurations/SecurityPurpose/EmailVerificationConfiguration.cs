using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart_E_Commerce_Management_System.Data.Entities.User;

namespace TechMart_E_Commerce_Management_System.Data.Configurations.SecurityPurpose
{
    public class EmailVerificationConfiguration
        : IEntityTypeConfiguration<EmailVerification>
    {
        public void Configure(EntityTypeBuilder<EmailVerification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VerificationCode)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.ExpiryTime)
                .IsRequired();
            builder.Property(x => x.IsUsed)
                .HasDefaultValue(false);
            builder.HasOne(x => x.User)
                .WithMany(u => u.EmailVerficationsCodes)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
