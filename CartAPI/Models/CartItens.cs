namespace CartAPI.Models
{
    public class CartItens
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Products? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
    }

}
