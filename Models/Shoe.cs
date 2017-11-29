using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Shoe
    {
        public int Id { get; set; } 
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public ICollection<ShoeStyle> ShoeStyles { get; set; }

        public Shoe()
        {
            ShoeStyles = new Collection<ShoeStyle>();
        }
    }
}