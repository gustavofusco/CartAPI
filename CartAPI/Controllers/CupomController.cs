using CartAPI.Services.CupomService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomService _cupomService;

        public CupomController(ICupomService cupomService)
        {
            _cupomService = cupomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cupom>>> GetAll()
        {
            return await _cupomService.GetAll();
        }

        [HttpPost("{codigo}/{idUser}")]
        public async Task<ActionResult<Cupom>> ApplyCupom(string codigo, int idUser)
        {
            var result = await _cupomService.ApplyCupom(codigo, idUser);

            if (result is null)
                return NotFound("Cupom inválido ou expirado!");


            return Ok($"Cupom de {(int)result.Desconto}% aplicado com sucesso!");
        }
    }
}
