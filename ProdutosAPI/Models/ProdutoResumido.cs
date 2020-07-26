using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class ProdutoResumido
    {
        public string Nome { get; set; }
        public float Valor { get; set; }
        public int QtdEstoque { get; set; }

        public ProdutoResumido(string nome, float valor, int qtdEstoque)
        {
            Nome = nome;
            Valor = valor;
            QtdEstoque = qtdEstoque;
        }

        public ProdutoResumido()
        {
        }
    }
}
