using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Core;
using ShoeStore.Core.Models;

namespace ShoeStore.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ShoeStoreDbContext _context;
        public PhotoRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Photo>> GetColorsAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Photo photo)
        {
            _context.Photos.Add(photo);
        }

        public void Add(ICollection<Photo> photos)
        {
            foreach (var photo in photos)
                _context.Photos.Add(photo);
        }
    }
}