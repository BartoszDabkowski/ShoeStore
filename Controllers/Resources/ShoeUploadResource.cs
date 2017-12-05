using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Controllers.Resources
{
    public class ShoeUploadResource
    {
        [Required]
        public int BrandId { get; set; } 
        [Required]
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