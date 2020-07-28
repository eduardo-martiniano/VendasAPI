using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repository;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private DatabaseContext _db;

        public ComprasController(DatabaseContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Compra compra)
        {
            DateTime data = DateTime.Now;
            Produto p = _db.Produtos.Find(compra.produto_id);
            p.data_ultima_venda = data;
            p.qtde_estoque = p.qtde_estoque - 1;
            _db.SaveChanges();
            return Ok("Compra realizada com sucesso!");

        }
    }
}
