using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Core.Models;

namespace ShoeStore.Core
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetShoesAsync();
        Task<Shoe> GetShoeAsync(int id, bool includeRelated = true);
        void Add(Shoe shoe);
    }
}