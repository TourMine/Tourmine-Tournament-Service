using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure.Context;

namespace Tourmine.Tournament.Infrastructure.Persistence.Repositories
{
    public class TournamentRepository : ITournamentRepository
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
    }
}
