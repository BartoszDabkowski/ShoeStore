using ShoeStore.Models;

namespace ShoeStore.Persistence.Interface
{
    public interface IInventoryRepository
    {
        void Add(Inventory inventory);
    }
}