namespace Tourmine.Tournament.Domain.Interfaces.Services
{
    public interface IRabbitMqPublisher
    {
        Task PublishSubscriptionCreatedEvent(Guid tournamentId, Guid userId);
    }
}
