using CartAPI.Models;
using System.Buffers.Text;

namespace CartAPI.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        public CartService(DataContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCart(int idUser)
        {
            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == idUser);

            return cart;
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
            var product = await _context.Products.FindAsync(idProduct);

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

        public async Task<Cart> UpdateProductOnCart(updateProd baseP)
        {
            var user = await _context.Users.FindAsync(baseP.IdUser);
            var product = _context.Products.FirstOrDefault(p => p.Id == baseP.IdProduct);
            if (product is null || user is null)
            {
                return null;
            }

            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == baseP.IdUser);
            var cartItem = cart.Itens?.FirstOrDefault(ci => ci.ProdutoId == baseP.IdProduct);

            if(baseP.Qtd == 0)
            {
                await RemoveItenOnCart(baseP.IdUser, baseP.IdProduct);
            }
            else
            {
                cartItem.Quantidade = baseP.Qtd;
                cartItem.Subtotal = (decimal)(cartItem.Produto.Preco * baseP.Qtd);
            }

            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<Cart> DropCart(int idUser)
        {
            var cart = _context.Cart.Include(c => c.Itens).FirstOrDefault(c => c.UserId == idUser);
            var user = await _context.Users.FindAsync(idUser);
            var cartItems = _context.Cart.Include(c => c.Itens).ToList();
            if (cart != null)
            {
                _context.Cart.RemoveRange(cartItems); // ACHO QUE VAI DAR ERRO AQUI
                _context.Cart.Remove(cart);
                user.CarrinhoId = null;
                await _context.SaveChangesAsync();
            }

            return null;
        }

    }
}
