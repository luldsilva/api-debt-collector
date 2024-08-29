using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_debt_collector.Models
{
    public class ParcelamentoModels
    {
        [Key]
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime? DataVencimentoParcela { get; set; }

        [JsonIgnore]
        [ForeignKey("DebitModel")]
        public int id_debit { get; set; }
        [JsonIgnore]
        public DebitModel? DebitDataModel { get; set; }
    }
}
