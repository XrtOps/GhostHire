using Microsoft.EntityFrameworkCore;
using GhostHire.Models;

namespace GhostHire.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<Authentication> authentications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentication>().HasData(new Authentication
            {
                AuthenticationID = 1,
                Username = "ghostHire",
                Password = "ghostHire",
                PasswordConfirmation = "ghostHire"
            });
        }

    }
}
