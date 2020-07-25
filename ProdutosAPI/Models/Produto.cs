using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class Produto
    {
        [Key]
        public int produto_id { get; set; }
        [Required(ErrorMessage = "A Propriedade nome é obrigatoria!")]
        public string nome { get; set; }
        [Required(ErrorMessage = "A Propriedade valor é obrigatoria!")]
        public float valor_unitario { get; set; }
        [Required(ErrorMessage = "A Propriedade Quantidade em estoque é obrigatoria!")]
        public int qtde_estoque { get; set; }
        public DateTime data_ultima_venda { get; set; }
        public float valor_ultima_venda { get; set; }

    }
}
