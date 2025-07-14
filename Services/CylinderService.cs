using GasStationApi.Data;
using AutoMapper;
using GasStationApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using GasStationApi.Services.IServices;
using GasStationApi.Models;

namespace GasStationApi.Services
{
    public class CylinderService : ICylinder
    {
        private readonly GasDbContext _context;
        private readonly IMapper _mapper;

        public CylinderService(GasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task <List<CylinderDTO>> GetAllCylindersAsync()
        {
            var cylinders = await _context.Cylinders.ToListAsync();
            return _mapper.Map<List<CylinderDTO>>(cylinders);
        }

        public async Task<CylinderDTO?> GetCylinderByIdAsync(Guid cylinderId)
        {
            var cylinder = await _context.Cylinders.FirstOrDefaultAsync(c => c.Id == cylinderId);
            if(cylinder == null) return null;
            return _mapper.Map<CylinderDTO>(cylinder);
        }

        public async Task<CylinderDTO> AddCylinderAsync(AddUpdateCylinderDTO newCylinder)
        {
            var cylinder = _mapper.Map<Cylinder>(newCylinder);
            cylinder.Id = Guid.NewGuid();
            await _context.Cylinders.AddAsync(cylinder);
            await _context.SaveChangesAsync();
            return _mapper.Map<CylinderDTO>(cylinder);
        }

        public async Task UpdateCylinderAsync(AddUpdateCylinderDTO updatedCylinder, Guid cylinderId)
        {
            var existing = await _context.Cylinders.FindAsync(cylinderId);
            if(existing == null) return;
            _mapper.Map(updatedCylinder, existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCylinderAsync(Guid cylinderId)
        {
            var cylinder = await _context.Cylinders.FindAsync(cylinderId);
            if(cylinder == null) return;
            _context.Cylinders.Remove(cylinder);
            await _context.SaveChangesAsync();
        }
        
    }
}