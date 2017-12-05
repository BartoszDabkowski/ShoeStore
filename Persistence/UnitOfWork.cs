using System.Threading.Tasks;

namespace ShoeStore.Persistence
{
    public class UnitOfWork
    {
        private readonly ShoeStoreDbContext _context;

        public UnitOfWork(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}