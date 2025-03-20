using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Tourmine.Tournament.Domain.Interfaces.Services;

namespace Tourmine.Tournament.Infrastructure.Persistence.Service
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqPublisher()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public async Task PublishSubscriptionCreatedEvent(Guid tournamentId, Guid userId)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync("tournament.notifications", ExchangeType.Direct);

            var message = JsonSerializer.Serialize(new
            {
                Type = "Subscription",
                TournamentId = tournamentId,
                UserId = userId,
                Timestamp = DateTime.UtcNow
            });

            var bytesMessage = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "tournament.notifications",
                routingKey: "subscription", 
                body: bytesMessage
            );

            Console.WriteLine(" [x] Sent Subscription Event: {0}", message);
        }

        public async Task PublishTournamentCreatedEvent(Guid tournamentId)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync("tournament.notifications", ExchangeType.Direct);

            var message = JsonSerializer.Serialize(new
            {
                Type = "TournamentCreated",
                TournamentId = tournamentId,
                Timestamp = DateTime.UtcNow
            });

            var bytesMessage = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "tournament.notifications",
                routingKey: "creation",
                body: bytesMessage
            );

            Console.WriteLine(" [x] Sent Tournament Created Event: {0}", message);
        }
    }
}
