namespace CartAPI.Services.CartService
{
    public interface ICartService
    {
        List<Cart> GetAllCart();
        Cart? GetCartById(int id);
        List<Cart> AddCart(Cart cartAdd);
        List<Cart>? UpdateCart(int id, Cart cartPut);
        List<Cart>? DelOneCart(int id);
    }
}
