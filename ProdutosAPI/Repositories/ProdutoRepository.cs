using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private DatabaseContext _db;

        public ProdutoRepository(DatabaseContext db)
        {
            _db = db;
        }
        public IEnumerable<ProdutoResumido> listarProdutos()
        {
            List<ProdutoResumido> produtos = new List<ProdutoResumido>();
            foreach (var item in _db.Produtos)
            {
                ProdutoResumido novoProduto = new ProdutoResumido(item.produto_id, item.nome, item.valor_unitario, item.qtde_estoque);
                produtos.Add(novoProduto);
            }
            return produtos;
        }
        public void Cadastrar(Produto produto)
        {
            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        public void DeleteProduto(int id)
        {
            _db.Produtos.Remove(_db.Produtos.Find(id));
            _db.SaveChanges();
        }
        public void EditarProduto(int id, Produto produto)
        {
            var p = _db.Produtos.Find(id);
            p.nome = produto.nome;
            p.valor_unitario = produto.valor_unitario;
            p.qtde_estoque = produto.qtde_estoque;
            _db.Produtos.Update(p);
            _db.SaveChanges();
        }

        public Produto GetProduto(int id)
        {
            return _db.Produtos.Find(id);
        }


    }
}
