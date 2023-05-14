using CartAPI.Services.CartService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{idUser}")]
        public async Task<ActionResult<Cart>> GetCart(int idUser)
        {
            var result = await _cartService.GetCart(idUser);

            if (result == null)
                return NotFound("Carrinho não encontrado");

            if (result.Itens.Count == 0)
                return NotFound("Carrinho está vazio.");

            return result;
        }

        [HttpPost("{idUser}/{idProduct}")]
        public async Task<ActionResult<Cart>> AddCart(int idUser, int idProduct)
        {
            var result =  await _cartService.AddItenOnCart(idUser, idProduct);
            if (result is null)
            {
                return NotFound("Produto ou Usuário não existe");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Cart>> UpdateItenOnCart(updateProd update)
        {
            var result = await _cartService.UpdateProductOnCart(update);

            if (result is null)
                return NotFound("Encontramos erros na formatação");

            return Ok(result);
        }

        [HttpDelete("{idUser}/{idProduct}")]
        public async Task<ActionResult<Cart>> RemoveItenOnCart(int idUser, int idProduct)
        {
            var result = await _cartService.RemoveItenOnCart(idUser, idProduct);

            if (result is null)
            {
                return NotFound("Produto ou Usuário não existe");

            }

            return Ok(result);
        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult<Cart>> DropCart(int idUser)
        {
            await _cartService.DropCart(idUser);
            return Ok();
        }

    }
}
