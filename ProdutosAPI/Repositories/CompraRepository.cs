using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private DatabaseContext _db;

        public CompraRepository(DatabaseContext db)
        {
            _db = db;
        }
        public void BaixaNoProduto(int id, int quantidade)
        {
            DateTime data = DateTime.Now;
            Produto p = _db.Produtos.Find(id);
            p.data_ultima_venda = data;
            p.qtde_estoque = p.qtde_estoque - quantidade;
            p.valor_ultima_venda = p.valor_unitario * quantidade;
            _db.Produtos.Update(p);
            _db.SaveChanges();
        }

        public void Comprar(Compra compra)
        {
            BaixaNoProduto(compra.produto_id, compra.qtde_comprada);
        }
    }
}
