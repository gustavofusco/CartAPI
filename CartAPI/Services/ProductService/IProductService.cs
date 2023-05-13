namespace CartAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        // Task<List<Products>> UpdateProduct(int id, Products productPut);
        void AttProduct(int id, Products produto); // Atualizar valor do produto só quando retornar JSON FINAL
    }
}
