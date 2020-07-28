using ProdutosAPI.Data;
using ProdutosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repository
{
    public class ProdutoRepository
    {
        private DatabaseContext _db;
        public ProdutoRepository(DatabaseContext db)
        {
            _db = db;

        }
        public ProdutoRepository()
        {
                
        }

        public void baixaNoProduto(int id)
        {
            DateTime data = DateTime.Now;
            Produto p = _db.Produtos.Find(id);
            p.data_ultima_venda = data;
            p.qtde_estoque = p.qtde_estoque - 1;
            _db.SaveChanges();
        }

    }
}
