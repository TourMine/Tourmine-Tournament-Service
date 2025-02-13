using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure.Context;

namespace Tourmine.Tournament.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Subscription subscription)
        {
            try
            {
                await _context.Subscriptions.AddAsync(subscription);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            try
            {
                _context.Update(subscription);
                var result = await _context.SaveChangesAsync();

                return subscription;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Subscription?> GetByIds(Guid tournamentId, Guid userId)
        {
            return await _context.Subscriptions
                .Where(subscription => subscription.TournamentId == tournamentId && subscription.UserId == userId)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Subscription>> GetAllByUserId(int start, int limit, Guid userId)
        {
            try
            {
                return await _context.Subscriptions
                    .Where(subscription => subscription.UserId == userId)
                    .Skip(start * limit)
                    .Take(limit)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Subscription>> GetAllByTournamentId(int start, int limit, Guid tournamentId)
        {
            try
            {
                return await _context.Subscriptions
                    .Where(subscription => subscription.TournamentId == tournamentId)
                    .Skip(start * limit)
                    .Take(limit)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
