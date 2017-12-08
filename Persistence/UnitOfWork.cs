using System.Threading.Tasks;

namespace ShoeStore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoeStoreDbContext _context;
        private readonly IShoeRepository _shoes;
        private readonly IColorRepository _colors;
        private readonly IStyleRepository _styles;
        private readonly ISizeRepository _sizes;
        private readonly IBrandRepository _brands;
        

        public IShoeRepository Shoes { get{
            return _shoes == null ? new ShoeRepository(_context) : _shoes;
        }}

        public IColorRepository Colors { get{
            return _colors == null ? new ColorRepository(_context) : _colors;
        }}

        public IStyleRepository Styles { get{
            return _styles == null ? new StyleRepository(_context) : _styles;
        }}

        public ISizeRepository Sizes { get{
            return _sizes == null ? new SizeRepository(_context) : _sizes;
        }}

        public IBrandRepository Brands { get{
            return _brands == null ? new BrandRepository(_context) : _brands;
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