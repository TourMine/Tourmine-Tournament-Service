using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _subcriptionRepository;
        public UpdateSubscriptionCommandHandler(ISubscriptionRepository subcriptionRepository)
        {
            _subcriptionRepository = subcriptionRepository;
        }

        public async Task<bool> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSubscription = await _subcriptionRepository.GetByIds(request.TournamentId, request.UserId);

                if (existingSubscription == null)
                {
                    throw new KeyNotFoundException($"Subscription com UserId {request.UserId} / e TournamentId { request.TournamentId } não encontrado.");
                }

                var updatedEntity = ToUpdate(existingSubscription, request.Request);

                return await _subcriptionRepository.Update(updatedEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Subscription ToUpdate(Subscription entity, UpdateSubscriptionRequest request)
        {
            entity.Status = request.Status;

            return entity;
        }
    }
}
