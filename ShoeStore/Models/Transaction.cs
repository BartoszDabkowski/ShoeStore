using System;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        [Required]
        public int Amount { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}