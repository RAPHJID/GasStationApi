using Microsoft.EntityFrameworkCore;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Services.IServices
{
    public interface InventoryInterface
    {
        Task <List<InventoryDTO>> GetAllInventoryAsync();
        Task <InventoryDTO> GetInventoryByIdAsync(Guid inventoryId);
        Task <InventoryDTO> AddInventoryAsync(AddUpdateInventory newInventory);
        Task UpdatedInventoryAsync(AddUpdateInventory updatedInventory, Guid inventoryId);
        Task DeleteInventoryAsync(Guid inventoryId);
    }
}