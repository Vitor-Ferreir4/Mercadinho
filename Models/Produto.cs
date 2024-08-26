using System.ComponentModel.DataAnnotations;

namespace Varejo.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required] // Adiciona validação obrigatória
        [MaxLength(100)] // Limita o tamanho do campo
        public string NomeProduto { get; set; }

        [Required] // Adiciona validação obrigatória
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser um valor positivo")]
        public decimal Preco { get; set; }

        [Required] // Adiciona validação obrigatória
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser um valor positivo")]
        public int QuantidadeEstoque { get; set; }

        [Required] // Adiciona validação obrigatória
        [MaxLength(100)] // Limita o tamanho do campo
        public string NomeCategoria { get; set; }

        [Required] // Adiciona validação obrigatória
        [MaxLength(100)] // Limita o tamanho do campo
        public string Fornecedor { get; set; }
    }
}
