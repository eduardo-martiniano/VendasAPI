﻿using System;
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
            if (ModelState.IsValid)
            {
                BaixaNoProduto(compra.produto_id, compra.qtde_comprada);
                return Ok("Compra realizada com sucesso!");
            }
            return BadRequest("Ocorreu um erro desconhecido");
        }
        public void BaixaNoProduto(int id, int quantidade)
        {
            DateTime data = DateTime.Now;
            Produto p = _db.Produtos.Find(id);
            p.data_ultima_venda = data;
            p.qtde_estoque = p.qtde_estoque - 1;
            p.valor_ultima_venda = p.valor_unitario * quantidade;
            _db.SaveChanges();
        }
    }
}
