using GasStationApi.Data;
using AutoMapper;
using GasStationApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using GasStationApi.Services.IServices;
using GasStationApi.Models;

namespace GasStationApi.Services
{
    public class TransactionService : ITransaction
    {
        private readonly IMapper _mapper;
        private readonly GasDbContext _context;

        public TransactionService(IMapper mapper, GasDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<TransactionDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _context.Transactions.ToListAsync();
            return _mapper.Map<List<TransactionDTO>>(transactions);
        }

        public async Task<TransactionDTO?> GetTransactionByIdAsync(Guid transactionId)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transactionId);
            if(transaction == null) return null;
            return _mapper.Map<TransactionDTO>(transaction);
        }

        public async Task<List<TransactionDTO>> GetTransactionsByDateAsync(DateTime date)
        {
            var transactions = await _context.Transactions
            .Where(t => t.Date.Date == date.Date)
            .ToListAsync();
            return _mapper.Map<List<TransactionDTO>>(transactions);

        }

        public async Task<List<TransactionDTO>> GetTransactionsByCustomerAsync(Guid customerId)
        {
            var transactions = await _context.Transactions
            .Where(t => t.CustomerId == customerId)
            .ToListAsync();
            return _mapper.Map<List<TransactionDTO>>(transactions);

        }

        public async Task<TransactionDTO> CreateTransactionAsync(AddTransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            transaction.Id = Guid.NewGuid();
            transaction.Date = DateTime.Now;
            await _context.Transactions.AddAsync(transactionDto);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteTransactionAsync(Guid transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if(transaction == null) return false;
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}