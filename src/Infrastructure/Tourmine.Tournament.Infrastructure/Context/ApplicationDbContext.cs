using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Infrastructure.Mappings;

namespace Tourmine.Tournament.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Entities.TournamentManagement.Tournament> Tournaments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public ApplicationDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TournamentMap());
        }
    }
}
