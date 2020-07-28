using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class Compra
    {
        [Required]
        public int produto_id { get; set; }
        [Required]
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }
    }
}
