using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeGardener.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlantController : Controller
    {
        public readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet("/Plants")]
        public async Task<IActionResult> GetAllPlants()
        {
            var plants = await _plantService.GetAllPlantsAsync();
            return Ok(plants);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlantById([FromRoute] int id)
        {
            var plant = await _plantService.GetPlantByIdAsync(id);
            if (plant == null)
                return NotFound();
            return Ok(plant);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlant([FromBody] PlantCreateRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            var plant = new Plant
            {
                PlantName = request.PlantName,
                PlantType = request.PlantType,
                PlantDescription = request.PlantDescription
            };
            var created = await _plantService.CreatePlantAsync(plant);
            if (created == null)
            {
                return Unauthorized();
            }
            return CreatedAtAction(nameof(GetPlantById), new { id = created.PlantID }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePlant([FromRoute] int id, [FromBody] PlantUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            var existing = await _plantService.GetPlantByIdAsync(id);
            if (existing == null)
                return NotFound();
            existing.PlantName = request.PlantName;
            var updated = await _plantService.UpdatePlantAsync(existing);
            if (updated == null)
                return BadRequest("Could not update plant");
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlant([FromRoute] int id)
        {
            var existing = await _plantService.GetPlantByIdAsync(id);
            if (existing == null)
                return NotFound();
            var deleted = await _plantService.DeletePlantAsync(id);
            if (!deleted)
                return BadRequest("Could not delete plant");
            return NoContent();
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
