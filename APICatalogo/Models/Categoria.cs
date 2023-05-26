using System.Collections.ObjectModel;

namespace APICatalogo.Models
{
    public class Categoria
    {
        // inicia a propriedade Produtos(coleção)
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; } // propriedade de navegação, que indica um para muitos, ou seja, uma Categoria contém uma coleção de Produtos
    }
}
