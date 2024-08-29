using api_debt_collector.Models;

namespace api_debt_collector.Repositories
{
    public interface IDebitRepository
    {
        Task CreateDebit(DebitModel debit);
        Task<List<DebitModel>> GetAllDebits();
    }
}
