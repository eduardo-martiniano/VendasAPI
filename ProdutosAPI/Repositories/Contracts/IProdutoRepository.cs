using ProdutosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        Produto GetProduto(int id);
        void Cadastrar(Produto produto);
        void DeleteProduto(int id);
        void EditarProduto(int id, Produto produto);
        IEnumerable<ProdutoResumido> listarProdutos();

    }
}
