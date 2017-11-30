using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<ShoeColor> ShoeColors { get; set; }

        public Color()
        {
            ShoeColors = new Collection<ShoeColor>();
        }
    }
}