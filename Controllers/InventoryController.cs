using Microsoft.AspNetCore.Mvc;
using GasStationApi.Services.IServices;
using GasStationApi.Services;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InventoryController : ControllerBase
    {
        private readonly InventoryInterface _inventoryService;

        public InventoryController(InventoryInterface inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventory()
        {
            var inventories = await _inventoryService.GetAllInventoryAsync();
            return Ok(inventories);
        }

        [HttpGet("{inventoryId}")]
        public async Task<IActionResult> GetInventoryById(Guid inventoryId)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(inventoryId);
            var response = new ResponseDto();
            if(inventory == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Inventory with Id {inventoryId} not found";
                return NotFound(response);
            }
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(AddUpdateInventory newInventory)
        {
            await _inventoryService.AddInventoryAsync(newInventory);
            return Ok(newInventory);
        }

        [HttpPut("{inventoryId}")]
        public async Task<IActionResult> UpdateInventory(AddUpdateInventory updatedInventory, Guid inventoryId)
        {
            var existing = await _inventoryService.GetInventoryByIdAsync(inventoryId);
            var response = new ResponseDto();
            if(existing == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Inventory with Id {inventoryId} not found";
                return NotFound(response);
            }
            await _inventoryService.UpdatedInventoryAsync(updatedInventory, inventoryId);
            return Ok(updatedInventory);
        }

        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteInventory(Guid inventoryId)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(inventoryId);
            var response = new ResponseDto();
            if(inventory == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Inventory with Id {inventoryId} not found";
                return NotFound(response);
            }
            await _inventoryService.DeleteInventoryAsync(inventoryId);
            return NotFound();
        } 


        
    }
}