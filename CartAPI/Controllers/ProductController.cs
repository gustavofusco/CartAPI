using CartAPI.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService;
        }
        /// <summary>
        /// Imprime todos produtos disponíveis
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }
    }
}
