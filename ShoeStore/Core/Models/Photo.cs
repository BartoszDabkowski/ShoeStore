using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
    }
}
