using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class ProdutoResumido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
        public int QtdEstoque { get; set; }

        public ProdutoResumido(int id, string nome, float valor, int qtdEstoque)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            QtdEstoque = qtdEstoque;
        }

        public ProdutoResumido()
        {
        }
    }
}
