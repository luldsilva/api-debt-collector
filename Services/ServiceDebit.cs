using api_debt_collector.Models;
using api_debt_collector.Repositories;
using System.Diagnostics;

namespace api_debt_collector.Services
{
    public class ServiceDebit : IServiceDebit
    {
        private readonly IDebitRepository _debitRepository;

        public ServiceDebit(IDebitRepository debitRepository)
        {
              _debitRepository = debitRepository;
        }
        public async Task DebitRegister(DebitModel debit)
        {
            if (debit.ModeloDeParcelamento != null)
            {
                foreach (var parcelamento in debit.ModeloDeParcelamento)
                {
                    parcelamento.DebitDataModel = debit;
                }
            }
            await _debitRepository.CreateDebit(debit);
        }

        public async Task<List<GetAllDebitsResult>> GetAllDebits()
        {
            var allDebits = await _debitRepository.GetAllDebits();


            var listAllDebitsResult = allDebits.Select(debit => new GetAllDebitsResult
            {
                NumeroDoTitulo = debit.Id,
                NomeDoCliente = debit.NomeCliente,
                QuantidadeDeParcelas = debit.NumeroDeParcelas,
                ValorOriginal = debit.ValorOriginal,
                DiasEmAtraso = CalculaDiasEmAtraso(debit),
                ValorAtualizado = CalculaValorAtualizado(debit),
                Juros = debit.PercentualJuros
            }).ToList();

            return listAllDebitsResult;

        }
        public int CalculaDiasEmAtraso(DebitModel debit)
        {
            if (debit.ModeloDeParcelamento == null) return 0;

            var diasEmAtraso = 0;

            foreach (var parcela in debit.ModeloDeParcelamento)
            {
                if (parcela.DataVencimentoParcela.HasValue && parcela.DataVencimentoParcela.Value < DateTime.Today)
                {
                    diasEmAtraso += (DateTime.Today - parcela.DataVencimentoParcela.Value).Days;
                }
            }

            return diasEmAtraso;
        }
        public decimal CalculaValorAtualizado(DebitModel debit)
        {
            if (debit.ModeloDeParcelamento == null) return debit.ValorOriginal;

            var valorAtualizado = debit.ValorOriginal;

            foreach (var parcela in debit.ModeloDeParcelamento)
            {
                if (parcela.DataVencimentoParcela.HasValue && parcela.DataVencimentoParcela.Value < DateTime.Today)
                {
                    var diasEmAtraso = (DateTime.Today - parcela.DataVencimentoParcela.Value).Days;
                    var valorJuros = parcela.ValorParcela * (debit.PercentualJuros / 100.0m) * diasEmAtraso;
                    var valorMulta = parcela.ValorParcela * (debit.PercentualMulta / 100.0m);
                    valorAtualizado += valorJuros + valorMulta;
                }
            }
            return valorAtualizado;
        }

    }
}
