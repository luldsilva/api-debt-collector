using api_debt_collector.Models;

namespace api_debt_collector.Services
{
    public interface IServiceDebit
    {
        Task DebitRegister(DebitModel debit);
        Task<List<GetAllDebitsResult>> GetAllDebits();
    }
}
