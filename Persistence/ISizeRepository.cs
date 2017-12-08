using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public interface ISizeRepository
    {
        Task<IEnumerable<Size>> GetSizesAsync();
    }
}