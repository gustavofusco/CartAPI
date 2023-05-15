namespace CartAPI.Services.CartService
{
    public interface ICartService
    {
        Task<Cart> GetCart(int idUser);
        Task<Cart> FinishCart(int idUser);
        Task<Cart> AddItenOnCart(int idUser, int idProduct);
        Task<Cart> UpdateProductOnCart(int idUser, int idProduct, int Qtd);
        Task<Cart> RemoveItenOnCart(int idUser, int idProduct);
        Task<Cart> DropCart(int idUser);
    }


}
