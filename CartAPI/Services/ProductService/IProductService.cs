namespace CartAPI.Services.CartService
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Products? GetProductById(int id);
        List<Products> AddProduct(Products cartAdd);
        List<Products>? UpdateProduct(int id, Products cartPut);
        List<Products>? DelOneProduct(int id);
    }
}
