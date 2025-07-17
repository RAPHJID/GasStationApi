using GasStationApi.Models.DTOs;

namespace GasStationApi.Service.IService
{
    public interface ITransaction
    {
        Task<List<TransactionDTO>> GetAllTransactionsAsync();
        Task<TransactionDTO?> GetTransactionByIdAsync(Guid transactionId);
        Task<List<TransactionDTO>> GetTransactionsByDateAsync(DateTime date);
        Task<List<TransactionDTO>> GetTransactionsByCustomerAsync(Guid customerId);

        Task<TransactionDTO> CreateTransactionAsync(AddTransactionDTO transactionDto);
        Task<bool> DeleteTransactionAsync(Guid transactionId);
    }
}
