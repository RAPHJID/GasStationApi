using Microsoft.EntityFrameworkCore;
using GasStationApi.Models.DTOs;


namespace GasStationApi.Services.IServices
{
    public interface ICylinder
    {
        Task <List<Cylinder>> GetAllCylinders();
        Task <CylinderDTO> GetCylinderByIdAsync(Guid cylinderId);
        Task <CylinderDTO> AddCylinderAsync(AddUpdateCylinderDTO newCylinder, Guid cylinderId);
        Task UpdateCylinderAsync(AddUpdateCylinderDTO updatedCylinder, Guid cylinderId);
        Task DeleteCylinderAsync(Guid cylinderId);
        
    }
}