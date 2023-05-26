using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext : DbContext
    {
        //construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // mapeamento das entidades
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
