using Microsoft.AspNetCore.Mvc;
using GasStationApi.Services.IServices;
using GasStationApi.Services;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _service.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransactionById(Guid transactionId)
        {
            var transaction = await _service.GetTransactionByIdAsync(transactionId);
            var response = new ResponseDto();
            if(transaction == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Transaction with Id {transactionId} not found";
                return NotFound(response);
            }
            return Ok(transaction);
        }

        [HttpGet("{transactionDate}")]
        public async Task<IActionResult> GetTransactionsByDate(DateTime date)
        {
            var transactions = await _service.GetTransactionsByDateAsync(date);
            return Ok(transactions);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetTransactionsByCustomer(Guid customerId)
        {
            var transactions = await _service.GetTransactionsByCustomerAsync(customerId);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(AddTransactionDTO transactionDto)
        {
            var transaction = await _service.CreateTransactionAsync(transactionDto);
            var response = new ResponseDto();
            if(transaction == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Transaction not found";
                return NotFound(response);
            }
            return Ok(transaction);

        }

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> DeleteTransaction(Guid transactionId)
        {
            var transaction = await _service.GetTransactionByIdAsync(transactionId);
            var response = new ResponseDto();
            if(transaction == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Transaction with Id {transactionId} not found";
                return NotFound(response);
            }
            await _service.DeleteTransactionAsync(transactionId);
            return NotFound();

        }


        
    }

}