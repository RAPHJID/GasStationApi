namespace GasStationApi.Services.IServices
{
    public interface ICustomer
    {
        Task <List<CustomerDTO>> GetAllCustomersAsync();
        Task <CustomerDTO> GetCustomerByIdAsync(customerId);
        Task <CustomerDTO> AddCustomerAsync(AddUpdateCustomerDTO newCustomer);
        Task UpdateCustomerAsync(Guid customerId, AddUpdateCustomerDTO updateCustomer);
        Task DeleteCustomerAsync(Guid customerId);
    }
}