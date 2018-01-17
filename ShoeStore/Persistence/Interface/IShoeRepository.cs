using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence.Interface
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetShoesAsync();
        Task<Shoe> GetShoeAsync(int id, bool includeRelated = true);
        void Add(Shoe shoe);
    }
}