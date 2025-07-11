using Microsoft.AspNetCore.Mvc;
using GasStationApi.Services.IServices;
using GasStationApi.Services;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            var response = new ResponseDto();
            if(customer == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Customer with ID {customerId} not found!";
                return NotFound(response);
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddUpdateCustomerDTO newCustomer)
        {
            await _customerService.AddCustomerAsync(newCustomer);
            return Ok(newCustomer);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(Guid customerId, AddUpdateCustomerDTO updateCustomer)
        {
            var existing = await _customerService.GetCustomerByIdAsync(customerId);
            var response = new ResponseDto();
            if(existing == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Customer with ID {customerId} not found!";
                return NotFound(response);
            }
            await _customerService.UpdateCustomerAsync(customerId, updateCustomer);
            return Ok(updateCustomer);
        }


        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            var response = new ResponseDto();
            if(customer == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Customer with Id {customerId} not found";
                return NotFound(response);
            }
            await _customerService.DeleteCustomerAsync(customerId);
            return NoContent();
        }



        
    }
}