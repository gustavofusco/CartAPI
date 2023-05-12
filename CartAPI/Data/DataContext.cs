global using Microsoft.EntityFrameworkCore;

namespace CartAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItens> ItensCart { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLSERVER;Database=cartapidb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuração das tabelas de Identity

            modelBuilder.Entity<Products>().HasData(
        new Products { Id = 1, Nome = "Geladeira", Preco = 5050, Descricao = "Geladeira eletro 127v", Estoque = 8, Ativo = true },
        new Products { Id = 2, Nome = "Fogão", Preco = 1200, Descricao = "Fogão 5 Bocas", Estoque = 3, Ativo = true },
        new Products { Id = 3, Nome = "Sofá", Preco = 1800, Descricao = "Sofá cama com suporte", Estoque = 5, Ativo = true },
        new Products { Id = 4, Nome = "Mesa Jantar", Preco = 780, Descricao = "Mesa de jantar com 4 lugares", Estoque = 2, Ativo = true },
        new Products { Id = 5, Nome = "Guarda-Roupas", Preco = 950, Descricao = "Guarda-roupas com 3 portas", Estoque = 15, Ativo = true }
    );


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Nome = "Mario" },
                new User { Id = 2, Nome = "Vanessa" },
                new User { Id = 3, Nome = "Victor" }
            );

            modelBuilder.Entity<Cupom>().HasData(
                new Cupom { Id = 1, Codigo = "DESCONTAO", Desconto = 10 },
                new Cupom { Id = 2, Codigo = "CINQUENTAOFF", Desconto = 50 },
                new Cupom { Id = 3, Codigo = "FELIZNATAL", Desconto = 25 }
            );
        }
    }
}
