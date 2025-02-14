using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Infrastructure.Mappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(subscription => new { subscription.TournamentId, subscription.UserId });

            builder
                .HasOne<Domain.Entities.TournamentManagement.Tournament>()
                .WithMany()
                .HasForeignKey(subscription => subscription.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(subscription => subscription.UserId)
                .IsRequired();

            builder
               .Property(subscription => subscription.SubscrpitionDate)
               .IsRequired();
        }
    }
}
