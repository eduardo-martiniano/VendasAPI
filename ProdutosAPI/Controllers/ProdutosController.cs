using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Data;
using ProdutosAPI.Models;


namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private DatabaseContext _db;

        public ProdutosController(DatabaseContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<ProdutoResumido> Get()
        {
            List<ProdutoResumido> produtos = new List<ProdutoResumido>();
            foreach (var item in _db.Produtos)
            {
                ProdutoResumido novoProduto = new ProdutoResumido(item.nome, item.valor_unitario, item.qtde_estoque);
                produtos.Add(novoProduto);
            }
            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ocorreu um erro desconhecido!");
            }

            var produto = await _db.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _db.Add(produto);
                _db.SaveChanges();
                return Ok("Produto cadastrado com sucesso!");
            }
            else
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await _db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _db.Produtos.Remove(produto);
            await _db.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
