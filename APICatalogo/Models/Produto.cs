namespace APICatalogo.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; } // mapeia a coluna categoriaId - FK
        public Categoria? Categoria { get; set; } // propriedade de navegação, ou seja, um produto está relacionado a uma categoria
    }
}
