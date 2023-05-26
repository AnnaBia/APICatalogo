using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        // instância da classe appContext
        // readonly: apenas leitura
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() // Por que IEnumerable ao invés de List<> ? Interface de leitura, permite adiar a execução, é otimizado
        {
            var produtos = _context.Produtos.AsNoTracking().ToList(); // _context permite acessar a base de dados da tabela Produtos, ToList() retorna a lista
            if (produtos is null) // se não houver produtos retorne um erro
            {
                return NotFound("Produtos não encontrados."); // NotFound() vem da classe abstrata ControllerBase
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id); // FirstOrDefault faz a busca e retorna null caso não encontre o id
            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto) // recebe um objeto
        {
            if(produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges(); // para persistir os valores no banco de dados

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto); // Em caso de êxito CreatedAtRouteResult() retorna 201, solicita a rota de sucesso, através do id e o objeto produto adicionado
        }

        [HttpPut("{id:int}")] // HttpPut solicita a atualização de todos os dados
        public ActionResult Put(int id, Produto produto) // Para a atualização é necessário passar o id e os dados do produto
        {
            if( id != produto.ProdutoId) // Caso o id digitado não seja o mesmo do Produto, retorne erro
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified; // Entry() indica o status da entidade, nesse caso, pode ser modificada
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não localizado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
