using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShoeStore.Controllers.Resources
{
    public class BrandResource : KeyValuePairResource
    {
        public ICollection<ShoeResource> Shoes { get; set; }

        public BrandResource()
        {
            Shoes = new Collection<ShoeResource>();
        }
    }
}