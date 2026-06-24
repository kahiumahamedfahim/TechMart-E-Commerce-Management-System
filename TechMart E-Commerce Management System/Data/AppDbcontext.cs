using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data.Entities;

namespace TechMart_E_Commerce_Management_System.Data
{
    public class AppDbcontext
       : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailVerification> EmailVerification { get; set; }
        public DbSet<PasswordResetCode> PasswordResetCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbcontext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
