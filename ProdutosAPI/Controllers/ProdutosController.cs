using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Contracts;
using Remotion.Linq.Utilities;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository _repository;
        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<ProdutoResumido> Get()
        {
            var produtos = _repository.listarProdutos();
            return produtos;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto([FromRoute] int id)
        {
            if (_repository.GetProduto(id) == null)
            {
                return NotFound("Talvez o Produto não exista!");
            }

            var produto = _repository.GetProduto(id);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repository.Cadastrar(produto);
                return Ok("Produto cadastrado com sucesso!");
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto([FromRoute] int id)
        {
            if (_repository.GetProduto(id) == null)
            {
                return NotFound("Talvez o Produto não exista!");
            }
            _repository.DeleteProduto(id);
            return Ok("Produto removido com sucesso!");
        }
        [HttpPut("{id}")]
        public IActionResult EditarProduto(int id, [FromBody] Produto produto)
        {
            if (_repository.GetProduto(id) == null)
            {
                return NotFound("Talvez o Produto não exista!");
            }
            _repository.EditarProduto(id, produto);
            return Ok("Produto editado com sucesso!");
        }
        
    }
}
