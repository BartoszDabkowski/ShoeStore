using System.Threading.Tasks;

namespace ShoeStore.Persistence.Interface
{
    public interface IUnitOfWork
    {
        IShoeRepository Shoes { get;}
        IColorRepository Colors { get;}
        IStyleRepository Styles { get;}
        ISizeRepository Sizes { get;}
        IBrandRepository Brands { get;}
        IInventoryRepository Inventory { get;}
        Task CompleteAsync();
    }
}