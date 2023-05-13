using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class Cupom
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
    }

}