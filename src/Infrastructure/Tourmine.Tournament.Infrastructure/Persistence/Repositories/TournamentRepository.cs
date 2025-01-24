using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure.Context;

namespace Tourmine.Tournament.Infrastructure.Persistence.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSession _dbSession;

        public TournamentRepository(ApplicationDbContext context, DbSession dbSession)
        {
            _context = context;
            _dbSession = dbSession;
        }

        public async Task<bool> Create(Domain.Entities.TournamentManagement.Tournament tournament)
        {
            try
            {
                await _dbSession.BeginTransactionAsync();

                await _context.Tournaments.AddAsync(tournament);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    await _dbSession.CommitAsync();
                    return true;
                }

                await _dbSession.RollbackAsync();
                return false;

            }
            catch (Exception ex)
            {
                await _dbSession.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
