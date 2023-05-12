using Microsoft.EntityFrameworkCore;

namespace CartAPI.Services.CartService
{
    public class ProductService : IProductService
    {
        private static List<Products> product = new List<Products>
            {
                new Products {
                    Id = 1,
                    Nome = "Geladeira",
                    Estoque = 5,
                    Descricao = "Geladeira Branca",
                    Preco = 5555.20,
                    Ativo = true
                },
                new Products {
                    Id = 2,
                    Nome = "Fogão",
                    Estoque = 5,
                    Descricao = "Fogão 5 Bocas",
                    Preco = 2000,
                    Ativo = true
                },
                new Products {
                    Id = 3,
                    Nome = "Sofá",
                    Estoque = 5,
                    Descricao = "Geladeira Branca",
                    Preco = 5555.20,
                    Ativo = true
                },
            };

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

        public Products GetProductById(int id)
        {
            var oneCart = product.Find(x => x.Id == id);

            if (oneCart is null)
                return null;


            return oneCart;
        }

        public List<Products> AddProduct(Products cartAdd)
        {
            product.Add(cartAdd);

            return product;
        }


        public List<Products>? UpdateProduct(int id, Products cartPut)
        {
             var oneCart = product.Find(x => x.Id == id);

            if (oneCart is null)
                return null;

            string[] values = { cartPut.Nome, cartPut.Descricao };

            bool strings = values.Any(x => x.Contains("string"));

            if (strings)
                return null;

            oneCart.Nome = cartPut.Nome;
            oneCart.Preco = cartPut.Preco;
            oneCart.Estoque = cartPut.Estoque;
            oneCart.Descricao = cartPut.Descricao;

            return product;
        }

        public List<Products>? DelOneProduct(int id)
        {
            var oneCart = product.Find(x => x.Id == id);

            if (oneCart is null)
                return null;


            product.Remove(oneCart);

            return product;
        }

        
    }
}
