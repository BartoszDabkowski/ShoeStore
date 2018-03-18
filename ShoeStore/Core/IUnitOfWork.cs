using System.Threading.Tasks;

namespace ShoeStore.Core
{
    public interface IUnitOfWork
    {
        IShoeRepository Shoes { get;}
        IColorRepository Colors { get;}
        IStyleRepository Styles { get;}
        ISizeRepository Sizes { get;}
        IBrandRepository Brands { get;}
        IInventoryRepository Inventory { get;}
        IPhotoRepository Photos { get; }
        Task CompleteAsync();
    }
}