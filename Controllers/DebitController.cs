using api_debt_collector.Models;
using api_debt_collector.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_debt_collector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DebitController : ControllerBase
    {
        private readonly IServiceDebit _serviceDebit;
        public DebitController(IServiceDebit serviceDebit)
        {
            _serviceDebit = serviceDebit;
        }

        [HttpPost("create-debit")]
        public async Task<ActionResult> CreateDebit(DebitModel debit)
        {
            try
            {
                await _serviceDebit.DebitRegister(debit);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get-all-debit")]
        public async Task<ActionResult<IAsyncEnumerable<GetAllDebitsResult>>> GetAllDebits()
        {
            try
            {
                var allDebits = await _serviceDebit.GetAllDebits();
                return Ok(allDebits);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
