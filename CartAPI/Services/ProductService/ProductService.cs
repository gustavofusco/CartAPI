namespace CartAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void AttProduct(int id, Products produto)
        {
            throw new NotImplementedException();
        }

        //public void AttProduct(int id, Products produto)
        //{
        //    var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == id);

        //    if (productToUpdate != null)
        //    {
        //        productToUpdate.Nome = produto.Nome;
        //        productToUpdate.Preco = produto.Preco;
        //        productToUpdate.Descricao = produto.Descricao;
        //        productToUpdate.Estoque = produto.Estoque;
        //        productToUpdate.Ativo = produto.Ativo;

        //        _context.SaveChanges();
        //    }
        //}

        public async Task<List<Products>> GetAllProducts()
        {   
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public Task<Products> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        //public Products GetProductById(int id)
        //{
        //    var oneCart = product.Find(x => x.Id == id);

        //    if (oneCart is null)
        //        return null;


        //    return oneCart;
        //}

        //public List<Products> AddProduct(Products cartAdd)
        //{
        //    product.Add(cartAdd);

        //    return product;
        //}


        //public async Task<List<Products>> UpdateProduct(int id, Products productPut)
        //{
        //    var oneProduct = await _context.Products.FindAsync(id);

        //    if (oneProduct is null)
        //        return null;

        //    string[] values = { cartPut.Nome, cartPut.Descricao };

        //    bool strings = values.Any(x => x.Contains("string"));

        //    if (strings)
        //        return null;

        //    oneCart.Nome = cartPut.Nome;
        //    oneCart.Preco = cartPut.Preco;
        //    oneCart.Estoque = cartPut.Estoque;
        //    oneCart.Descricao = cartPut.Descricao;

        //    return oneProduct;
        //}

        //public List<Products>? DelOneProduct(int id)
        //{
        //    var oneCart = product.Find(x => x.Id == id);

        //    if (oneCart is null)
        //        return null;


        //    product.Remove(oneCart);

        //    return product;
        //}


    }
}
