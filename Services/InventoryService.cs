using GasStationApi.Data;
using AutoMapper;
using GasStationApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using GasStationApi.Services.IServices;
using GasStationApi.Models;

namespace GasStationApi.Services
{
    public class InventoryService : InventoryInterface
    {
        private readonly GasDbContext _context;
        private readonly IMapper _mapper;

        public InventoryService(GasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InventoryDTO>> GetAllInventoryAsync()
        {
            var inventories = await _context.Inventory.ToListAsync();
            return _mapper.Map<List<InventoryDTO>>(inventories);
        } 

        public async Task<InventoryDTO?> GetInventoryByIdAsync(Guid inventoryId)
        {
            var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.Id == inventoryId);
            if(inventory == null) return null;
            return _mapper.Map<InventoryDTO>(inventory);
        }

        public async Task<InventoryDTO> AddInventoryAsync(AddUpdateInventory newInventory)
        {
            var inventory = _mapper.Map<Inventory>(newInventory);
            inventory.Id = Guid.NewGuid();
            await _context.Inventory.AddAsync(inventory);
            await _context.SaveChangesAsync();
            return _mapper.Map<InventoryDTO>(inventory);
        }

        public async Task UpdatedInventoryAsync(AddUpdateInventory updatedInventory, Guid inventoryId)
        {
            var existing = await _context.Inventory.FindAsync(inventoryId);
            if(existing == null) return;
            _mapper.Map(updatedInventory, existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(Guid inventoryId)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);
            if(inventory == null) return;
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        
    }
}