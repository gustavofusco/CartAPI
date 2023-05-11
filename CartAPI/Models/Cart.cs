namespace CartAPI.Models
{
    public class Cart
    {
        public int IdCart { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
