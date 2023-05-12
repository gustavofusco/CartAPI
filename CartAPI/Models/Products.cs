using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Estoque { get; set; }
        public bool Ativo { get; set; }

    }
}
