namespace Tourmine.Tournament.Application.Interfaces.SubscriptionManagement
{
    public interface ICancelSubscriptionUseCase
    {
        Task<bool> Execute(Guid tournamentId, Guid userId);
    }
}
