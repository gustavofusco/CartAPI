using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public virtual User? Usuario { get; set; }
        public virtual ICollection<CartItens>? Itens { get; set; }
        public int? CupomId { get; set; }
        public virtual Cupom? Cupom { get; set; }
    }
}
