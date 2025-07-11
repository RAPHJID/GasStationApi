using GasStationApi.Data;
using AutoMapper;
using GasStationApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using GasStationApi.Services.IServices;
using GasStationApi.Models;


namespace GasStationApi.Services
{
    public class CustomerService : ICustomer
    {
        private readonly GasDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(GasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ListAsync();
            return _mapper.Map<CustomerDTO>(customers);
        }
        
        public async Task<CustomerDTO?> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if(customer == null)  return null;
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> AddCustomerAsync(AddUpdateCustomerDTO newCustomer)
        {
            var customer = _mapper.Map<Customer>(newCustomer);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Guid customerId, AddUpdateCustomerDTO updateCustomer)
        {
            var existing = await _context.Customers.FindAsync(customerId);
            if(existing == null) return;
            _mapper.Map(updateCustomer, existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if(customer == null) return;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}