using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tourmine.Tournament.Infrastructure.Mappings
{
    public class TournamentMap : IEntityTypeConfiguration<Domain.Entities.TournamentManagement.Tournament>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TournamentManagement.Tournament> builder)
        {
            builder.ToTable("Tournaments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Game).IsRequired();
            builder.Property(x => x.Plataform).IsRequired();
            builder.Property(x => x.MaxTeams).IsRequired();
            builder.Property(x => x.TeamsType).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Prize).IsRequired();
            builder.Property(x => x.SubscriptionType).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate);
        }
    }
}
