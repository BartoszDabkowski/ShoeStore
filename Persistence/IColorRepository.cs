using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public interface IColorRepository
    {
         Task<IEnumerable<Color>> GetColorsAsync();
    }
}