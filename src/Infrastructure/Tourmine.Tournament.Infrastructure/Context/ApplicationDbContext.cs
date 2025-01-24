using Microsoft.EntityFrameworkCore;

namespace Tourmine.Tournament.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Entities.TournamentManagement.Tournament> Tournaments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // adiciona aqui
        }
    }
}
