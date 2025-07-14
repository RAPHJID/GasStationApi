using Microsoft.EntityFrameworkCore;
using GasStationApi.Models.DTOs;


namespace GasStationApi.Services.IServices
{
    public interface ICylinder
    {
        Task <List<CylinderDTO>> GetAllCylindersAsync();
        Task <CylinderDTO?> GetCylinderByIdAsync(Guid cylinderId);
        Task <CylinderDTO> AddCylinderAsync(AddUpdateCylinderDTO newCylinder);
        Task UpdateCylinderAsync(AddUpdateCylinderDTO updatedCylinder, Guid cylinderId);
        Task DeleteCylinderAsync(Guid cylinderId);
        
    }
}