using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_debt_collector.Models
{
    public class DebitModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public string? CpfCliente { get; set; }
        public int PercentualJuros { get; set; }
        public int PercentualMulta { get; set; }
        public int NumeroDeParcelas { get; set; }
        public decimal ValorOriginal { get; set; }
        public List<ParcelamentoModels>? ModeloDeParcelamento { get; set; }
    }
}
