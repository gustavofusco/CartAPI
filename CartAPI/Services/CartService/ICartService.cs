namespace CartAPI.Services.CartService
{
    public interface ICartService
    {
        Task<List<Cart>> GetCartById(int id);
        Task<Cart> AddItenOnCart(int idUser, int idProduct);
        Task<Cart> RemoveItenOnCart(int idUser, int idProduct);
        Task<Cart> UpdateProductOnCart(updateProd update);
        Task<Cart> DropCart(int idUser);
    }

    public class updateProd {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int Qtd { get; set; }
    }

}
