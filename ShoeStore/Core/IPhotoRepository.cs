using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Core.Models;

namespace ShoeStore.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetColorsAsync();
        void Add(Photo photo);
        void Add(ICollection<Photo> photos);
    }
}