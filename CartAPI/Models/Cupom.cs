namespace CartAPI.Models
{
    public class Cupom
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
    }

}
