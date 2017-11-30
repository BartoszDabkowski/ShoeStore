namespace ShoeStore.Models
{
    public class ShoeColor
    {
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}