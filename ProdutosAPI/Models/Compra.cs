using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class Compra
    {
        public int produto_id { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }
    }
}
