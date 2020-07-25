using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Produto> Get()
        {
            return _db.Produtos;
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
                return BadRequest(ModelState);
            }

        }
    }
}
