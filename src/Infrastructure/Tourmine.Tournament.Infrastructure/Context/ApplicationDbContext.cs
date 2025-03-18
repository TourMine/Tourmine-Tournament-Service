using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Infrastructure.Mappings;

namespace Tourmine.Tournament.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Entities.TournamentManagement.Tournament> Tournaments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TournamentMap());
            modelBuilder.ApplyConfiguration(new SubscriptionMap());
        }
    }
}
