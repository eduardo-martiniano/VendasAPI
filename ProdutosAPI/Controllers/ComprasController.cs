using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Contracts;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private ICompraRepository _repository;
        public ComprasController(ICompraRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _repository.Comprar(compra);
                return Ok("Compra realizada com sucesso!");
            }
            return BadRequest("Ocorreu um erro desconhecido");
        }
    }
}
