using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? CarrinhoId { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
