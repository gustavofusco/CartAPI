using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<List<Cart>>> GetAllCart()
        {
            return Ok(cart);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetOneCart(int id)
        {
            var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
            {
                return NotFound(new {error = "Este produto não existe"});
            }

            return Ok(oneCart);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cart>>> AddCart([FromBody]Cart cartPost)
        {
            cart.Add(cartPost);

            return Ok(cart);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Cart>>> UpdateCart(int id, Cart cartPut)
        {
            var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
                return NotFound(new { error = "Este produto não existe" });

            string[] values = { cartPut.ProductName, cartPut.Description };

            bool strings = values.Any(x => x.Contains("string"));

            if (strings)
                return NotFound(new { error = "Não aceitamos valores 'string'" });

            oneCart.ProductName = cartPut.ProductName;
            oneCart.ProductPrice = cartPut.ProductPrice;
            oneCart.Amount = cartPut.Amount;
            oneCart.Description = cartPut.Description;

            return Ok(oneCart);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DelOneCart(int id)
        {
            var oneCart = cart.Find(x => x.IdCart == id);

            if (oneCart is null)
                return NotFound(new { error = "Este produto não existe" });


            cart.Remove(oneCart);

            return Ok(oneCart);
        }
    }
}
