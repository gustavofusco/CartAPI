namespace CartAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);

        }
}
