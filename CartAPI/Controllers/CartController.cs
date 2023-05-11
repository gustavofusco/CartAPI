using CartAPI.Services.CartService;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) {
            _cartService = cartService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cart>>> GetAllCart()
        {
            return _cartService.GetAllCart();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetOneCart(int id)
        {
            
            var result = _cartService.GetCartById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cart>>> AddCart([FromBody]Cart cartPost)
        {
            var result = _cartService.AddCart(cartPost);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Cart>>> UpdateCart(int id, Cart cartPut)
        {
            var result = _cartService.UpdateCart(id, cartPut);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DelOneCart(int id)
        {
            var result = _cartService.DelOneCart(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
