namespace CartAPI.Services.CartService
{
    public class CartService : ICartService
    {
        private static List<Cart> cart = new List<Cart>
            {
                new Cart {
                    IdCart = 1,
                    ProductName = "Geladeira",
                    Amount = 5,
                    Description = "Geladeira Branca",
                    ProductPrice = 5555.20
                },
                new Cart {
                    IdCart = 2,
                    ProductName = "Fogão",
                    Amount = 2,
                    Description = "Fogão 5 bocas",
                    ProductPrice = 1600.99
                },
                new Cart {
                    IdCart = 3,
                    ProductName = "Sofá",
                    Amount = 1,
                    Description = "Sofá rosa",
                    ProductPrice = 789.99
                },
            };

        public List<Cart> GetAllCart()
        {
            return cart;
        }

        public Cart GetCartById(int id)
        {
            var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
                return null;


            return oneCart;
        }

        public List<Cart> AddCart(Cart cartAdd)
        {
            cart.Add(cartAdd);

            return cart;
        }

        public List<Cart>? DelOneCart(int id)
        {
            var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
                return null;


            cart.Remove(oneCart);

            return cart;
        }

        

        public List<Cart>? UpdateCart(int id, Cart cartPut)
        {
             var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
                return null;

            string[] values = { cartPut.ProductName, cartPut.Description };

            bool strings = values.Any(x => x.Contains("string"));

            if (strings)
                return null;

            oneCart.ProductName = cartPut.ProductName;
            oneCart.ProductPrice = cartPut.ProductPrice;
            oneCart.Amount = cartPut.Amount;
            oneCart.Description = cartPut.Description;

            return cart;
        }
    }
}
