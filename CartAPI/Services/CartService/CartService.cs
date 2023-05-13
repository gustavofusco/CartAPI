using CartAPI.Models;

namespace CartAPI.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        public CartService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetCartById(int id)
        {
            List<Cart> cartIdUser = await _context.Cart.ToListAsync();
            return cartIdUser;
        }

        public async Task<Cart> AddItenOnCart(int idUser, int idProduct)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == idUser);
            var product = _context.Products.FirstOrDefault(p => p.Id == idUser);

            if (product is null || user is null)
            {
                return null;
            }

            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == idUser);

            if (cart is null)
            {
                var cartItem = new CartItens
                {
                    ProdutoId = idUser,
                    Quantidade = 1,
                    Subtotal = (decimal)(product.Preco * 1),
                };

                var newCart = new Cart
                {
                    CreatedAt = DateTime.Now,
                    UserId = idUser,
                    CupomId = null,
                    Itens = new List<CartItens> { cartItem }
                };

                _context.Cart.Add(newCart);
                _context.SaveChanges();

                user.CarrinhoId = newCart?.Id;

                _context.Users.Update(user);
                _context.SaveChanges();

                return newCart;
            }
            else
            {
                var cartItem = cart.Itens?.FirstOrDefault(ci => ci.ProdutoId == idProduct);

                if (cartItem != null)
                {
                    cartItem.Quantidade++;
                    cartItem.Subtotal = (decimal)(cartItem.Produto.Preco * cartItem.Quantidade);
                }
                else
                {
                    var newCartItem = new CartItens
                    {
                        ProdutoId = idProduct,
                        Quantidade = 1,
                        Subtotal = (decimal)product.Preco
                    };
                    cart.Itens.Add(newCartItem);
                }
                _context.Cart.Update(cart);
                await _context.SaveChangesAsync();

                return cart;
            }

        }

        public async Task<Cart> RemoveItenOnCart(int idUser, int idProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == idProduct);

            if (product is null)
                return null;


            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == idUser);
            var cartItemToRemove = cart.Itens.FirstOrDefault(ci => ci.ProdutoId == idProduct);

            if (cartItemToRemove != null)
            {
                cart.Itens.Remove(cartItemToRemove);
                _context.SaveChanges();

            }

            return cart;
        }

        public Task<Cart> UpdateProductOnCart(updateProd baseP)
        {
            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == baseP.IdUser);
            var cartItemToRemove = cart.Itens.FirstOrDefault(ci => ci.ProdutoId == baseP.IdProduct);

            return null;
        }
    }
}
