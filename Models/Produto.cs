using System.ComponentModel.DataAnnotations;

namespace Varejo.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string NomeProduto { get; set; }

        [Required] 
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser um valor positivo")]
        public decimal Preco { get; set; }

        [Required] 
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser um valor positivo")]
        public int QuantidadeEstoque { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string NomeCategoria { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string Fornecedor { get; set; }
    }
}
