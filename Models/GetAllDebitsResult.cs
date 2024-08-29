namespace api_debt_collector.Models
{
    public class GetAllDebitsResult
    {
        public int NumeroDoTitulo { get; set; }
        public string? NomeDoCliente { get; set; }
        public int QuantidadeDeParcelas { get; set; }
        public decimal ValorOriginal { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorAtualizado { get; set; }
        public decimal Juros { get; set; }
    }
}
