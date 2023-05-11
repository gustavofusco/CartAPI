using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CreateDB : ControllerBase
    {
        [HttpOptions]
        public string CreateDatas()
        {
            return "Banco de dados criado com sucesso";
        }
    }
}
