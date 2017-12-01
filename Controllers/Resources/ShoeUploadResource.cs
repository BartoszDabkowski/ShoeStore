using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShoeStore.Controllers.Resources
{
    public class ShoeUploadResource
    {
        public int BrandId { get; set; } 
        public string Name { get; set; }
        public ICollection<int> Styles { get; set; }
        public ICollection<int> Colors { get; set; }

        public ShoeUploadResource()
        {
            Styles = new Collection<int>();
            Colors = new Collection<int>();
        }
    }
}