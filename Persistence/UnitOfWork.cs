using System.Threading.Tasks;

namespace ShoeStore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoeStoreDbContext _context;
        private IShoeRepository _shoes;
        private IColorRepository _colors;
        private IStyleRepository _styles;
        private ISizeRepository _sizes;
        private IBrandRepository _brands;
        

        public IShoeRepository Shoes { get{
            return _shoes = _shoes ?? new ShoeRepository(_context);
        }}

        public IColorRepository Colors { get{
            return _colors = _colors ?? new ColorRepository(_context);
        }}

        public IStyleRepository Styles { get{
            return _styles = _styles ?? new StyleRepository(_context);
        }}

        public ISizeRepository Sizes { get{
            return _sizes = _sizes ?? new SizeRepository(_context);
        }}

        public IBrandRepository Brands { get{
            return _brands = _brands ?? new BrandRepository(_context);
        }}

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