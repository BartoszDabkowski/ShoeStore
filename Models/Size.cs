using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        [Range(6, 16)]
        public double Name { get; set; }
    }
}