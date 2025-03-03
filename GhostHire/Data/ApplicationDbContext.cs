using Microsoft.EntityFrameworkCore;
using GhostHire.Models;

namespace GhostHire.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ServiceModel> Services { get; set; }
    }
}
