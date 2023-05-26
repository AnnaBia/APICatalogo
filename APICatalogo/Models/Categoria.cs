using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        // inicia a propriedade Produtos(coleção)
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; } // propriedade de navegação, que indica um para muitos, ou seja, uma Categoria contém uma coleção de Produtos
    }
}
