namespace Tourmine.Tournament.Application.Requests.SubscriptionManagement
{
    public class CreateSubscriptionRequest
    {
        public Guid TournamentId { get; set; }
        public Guid UserId { get; set; }
    }
}
