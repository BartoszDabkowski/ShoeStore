using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        [Range(6, 16)]
        public double Name { get; set; }
        public ICollection<ShoeSize> ShoeSizes { get; set; }

        public Size()
        {
            ShoeSizes = new Collection<ShoeSize>();
        }
    }
}