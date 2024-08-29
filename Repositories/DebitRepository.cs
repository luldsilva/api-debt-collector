using api_debt_collector.Data;
using api_debt_collector.Models;
using Microsoft.EntityFrameworkCore;

namespace api_debt_collector.Repositories
{
    public class DebitRepository : IDebitRepository
    {
        private readonly DataContext _context;
        public DebitRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateDebit(DebitModel debit)
        {
            try
            {
                _context.DebitDataModel.Add(debit);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.InnerException?.Message));
                throw;
            }
        }

        public async Task<List<DebitModel>> GetAllDebits()
        {
            return await _context.DebitDataModel
                   .Include(d => d.ModeloDeParcelamento) 
                   .ToListAsync();
        }
    }
}
