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

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Products>> GetOneCart(int id)
        //{
            
        //    var result = _productService.GetProductById(id);

        //    if (result is null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<Products>>> AddProduct([FromBody] Products productPost)
        //{
        //    var result = _productService.AddProduct(productPost);

        //    if (result is null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<List<Products>>> UpdateCart(int id, Products productPut)
        //{
        //    var result = _productService.UpdateProduct(id, productPut);

        //    if (result is null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Products>> DelOneProduct(int id)
        //{
        //    var result = _productService.DelOneProduct(id);

        //    if (result is null)
        //        return NotFound();

        //    return Ok(result);
        //}
    }
}
