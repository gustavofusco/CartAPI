namespace CartAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProducts()
        {   
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public Task<Products> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
