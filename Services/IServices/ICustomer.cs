using Microsoft.EntityFrameworkCore;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Services.IServices

{
    public interface ICustomer
    {
        Task <List<CustomerDTO>> GetAllCustomersAsync();
        Task <CustomerDTO?> GetCustomerByIdAsync(Guid customerId);
        Task <CustomerDTO> AddCustomerAsync(AddUpdateCustomerDTO newCustomer);
        Task UpdateCustomerAsync(Guid customerId, AddUpdateCustomerDTO updateCustomer);
        Task DeleteCustomerAsync(Guid customerId);
    }
}