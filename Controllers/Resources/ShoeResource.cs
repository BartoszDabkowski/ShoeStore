using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShoeStore.Controllers.Resources
{
    public class ShoeResource
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<KeyValuePairResource> Styles { get; set; }

        public ShoeResource()
        {
            Styles = new Collection<KeyValuePairResource>();
        }
    }
}