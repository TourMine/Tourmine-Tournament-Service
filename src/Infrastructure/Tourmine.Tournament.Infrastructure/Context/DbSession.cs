namespace Tourmine.Tournament.Infrastructure.Context
{
    public class DbSession : IDisposable
    {
        public readonly ApplicationDbContext _context;
        private Guid _id;

        public DbSession(ApplicationDbContext context)
        {
            _context = context;
            _id = Guid.NewGuid();
        }

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
