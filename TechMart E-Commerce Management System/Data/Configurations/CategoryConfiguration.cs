using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart_E_Commerce_Management_System.Data.Entities;

namespace TechMart_E_Commerce_Management_System.Data.Configurations
{
    public class CategoryConfiguration :
        IEntityTypeConfiguration<Catagory>
    {
        public void Configure(EntityTypeBuilder<Catagory> builder)
        {

            builder.ToTable("categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength
                (100);

            builder.Property(c => c.Code)
             .IsRequired()
             .HasMaxLength(20);

            builder.HasIndex(c => c.Code)
                .IsUnique();
            builder.Property(c => c.Description)
                  .HasMaxLength(500);

            // Image Path
            builder.Property(c => c.ImagePath)
                   .HasMaxLength(300);

            // IsActive
            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            // IsDeleted
            builder.Property(c => c.IsDeleted)
                   .HasDefaultValue(false);

            // CreatedAt
            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // LastUpdated
            builder.Property(c => c.LastUpdated)
                   .IsRequired(false);



        }
    }
}
