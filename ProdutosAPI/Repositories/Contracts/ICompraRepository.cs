using ProdutosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repositories.Contracts
{
    public interface ICompraRepository
    {
        void Comprar(Compra compra);
        void BaixaNoProduto(int id, int quantidade);
    }
}
