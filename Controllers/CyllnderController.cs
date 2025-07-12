using Microsoft.AspNetCore.Mvc;
using GasStationApi.Services.IServices;
using GasStationApi.Services;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CyllnderController : ControllerBase
    {
        private readonly ICylinder _cylinderService;

        public Cylinder(ICylinder cylinderService)
        {
            _cylinderService = cylinderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCylinders()
        {
            var cylinder = await _cylinderService.GetAllCylindersAsync();
            return Ok(cylinder);
        }

        [HttpGet("{cylinderId}")]
        public async Task<IActionResult>GetCylinderById(Guid cylinderId)
        {
            var cylinder = await _cylinderService.GetCylinderByIdAsync(cylinderId);
            var response = new ResponseDto();
            if(cylinder == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Cylinder with ID {cylinderId} not found";
                return NotFound(response);
            }
            return Ok(cylinder);
        }

        [HttpPost]
        public async Task<IActionResult> AddCylinder(AddUpdateCylinderDTO newCylinder)
        {
            await _cylinderService.AddCylinderAsync(newCylinder);
            return Ok(newCylinder);
        }

        [HttpPut("{cylinderId}")]
        public async Task UpdateCylinder(AddUpdateCylinderDTO updatedCylinder, Guid cylinderId)
        {
            var existing = await _cylinderService.GetCylinderByIdAsync(cylinderId);
            var response = new ResponseDto();
            if(existing == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Cylinder with ID {cylinderId} not found";
                return NotFound(response);
            }
            await _cylinderService.UpdateCylinderAsync(updatedCylinder);
            return Ok(updatedCylinder);
        }

        [HttpDelete]
        public async Task DeleteCylinder(Guid cylinderId)
        {
            var cylinder = await _cylinderService.GetCylinderByIdAsync(cylinderId);
            var response = new ResponseDto();
            if(cylinder == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Cylinder with ID {cylinderId} not found";
                return NotFound(response);
            }
            await _cylinderService.DeleteCylinderAsync(cylinderId);
            return NoContent();
        }
        
    }
}