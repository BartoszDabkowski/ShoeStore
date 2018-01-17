using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;

namespace ShoeStore.Persistence.Interface
{
    public interface IColorRepository
    {
         Task<IEnumerable<Color>> GetColorsAsync();
    }
}