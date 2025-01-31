using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Domain.Entities.TournamentManagement;
using Tourmine.Tournament.Domain.Enums;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure.Context;

namespace Tourmine.Tournament.Infrastructure.Persistence.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        private readonly ApplicationDbContext _context;

        public TournamentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Domain.Entities.TournamentManagement.Tournament tournament)
        {
            try
            {
                await _context.Tournaments.AddAsync(tournament);
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

        public async Task<Domain.Entities.TournamentManagement.Tournament?> GetById(Guid id)
        {
            try
            {
                return await _context.Tournaments
                    .Where(tournament => tournament.Id == id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Domain.Entities.TournamentManagement.Tournament> Update(Domain.Entities.TournamentManagement.Tournament entity)
        {
            try
            {
                _context.Update(entity);
                var result = await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<List<Domain.Entities.TournamentManagement.Tournament>> GetAll(int start, int limit, EPlataforms? plataforms, EParticipantsType? teamsTypes, ESubscriptionType? subscriptionTypes)
        {
            try
            {
                return await _context.Tournaments
                    .WhereIf(plataforms != null, tournament => tournament.Plataform == plataforms)
                    .WhereIf(teamsTypes != null, tournament => tournament.TeamsType == teamsTypes)
                    .WhereIf(subscriptionTypes != null, tournament => tournament.SubscriptionType == subscriptionTypes)
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
