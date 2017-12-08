using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public interface IStyleRepository
    {
         Task<IEnumerable<Style>> GetStylesAsync();
    }
}