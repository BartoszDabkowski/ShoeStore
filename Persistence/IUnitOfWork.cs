using System.Threading.Tasks;

namespace ShoeStore.Persistence
{
    public interface IUnitOfWork
    {
        IShoeRepository Shoes { get;}
        IColorRepository Colors { get;}
        IStyleRepository Styles { get;}
        ISizeRepository Sizes { get;}
        IBrandRepository Brands { get;}
        Task CompleteAsync();
    }
}