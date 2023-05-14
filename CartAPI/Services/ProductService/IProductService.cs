namespace CartAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        void AttProduct(int id, Products produto); // Atualizar valor do produto só quando retornar JSON FINAL
    }
}
