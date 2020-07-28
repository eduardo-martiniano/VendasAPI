using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class Cartao
    {
        [Required]
        public string titular { get; set; }
        [Required]
        [CreditCard(ErrorMessage = "Cartão de crédito inválido")]
        public string numero { get; set; }
        [Required]
        public string data_expiracao { get; set; }
        [Required]
        public string bandeira { get; set; }
        [Required]
        public string cvv { get; set; }
    }
}
