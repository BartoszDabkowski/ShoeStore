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
    }
}