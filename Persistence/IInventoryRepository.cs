using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public interface IInventoryRepository
    {
        void Add(Inventory inventory);
    }
}