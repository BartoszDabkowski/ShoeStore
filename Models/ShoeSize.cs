using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class ShoeSize
    {
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}