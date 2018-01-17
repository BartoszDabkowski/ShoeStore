using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence.Interface
{
    public interface IStyleRepository
    {
         Task<IEnumerable<Style>> GetStylesAsync();
    }
}