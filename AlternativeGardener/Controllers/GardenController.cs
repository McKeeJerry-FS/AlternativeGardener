using AlternativeGardener.Contracts.Gardens;
using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeGardener.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class GardenController : ControllerBase
    {
        private readonly IGardenService _gardenService;

        public GardenController(IGardenService gardenService)
        {
            _gardenService = gardenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGarden([FromBody] GardenCreateRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var garden = new Garden
            {
                GardenName = request.GardenName,
                GardenLocation = request.GardenLocation,
                GardenSize = request.GardenSize,
                GardenType = request.GardenType
            };

            var created = await _gardenService.CreateGardenAsync(garden);
            if (created == null)
            {
                return Unauthorized();
            }

            return CreatedAtAction(nameof(GetGardenById), new { id = created.GardenID }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGardenById([FromRoute] int id)
        {
            var all = await _gardenService.GetAllGardensAsync();
            var found = all.FirstOrDefault(g => g.GardenID == id);
            if (found == null)
                return NotFound();
            return Ok(found);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gardens = await _gardenService.GetAllGardensAsync();
            return Ok(gardens);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGarden([FromRoute] int id, [FromBody] GardenUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            var garden = new Garden
            {
                GardenName = request.GardenName,
                GardenLocation = request.GardenLocation,
                GardenSize = request.GardenSize,
                GardenType = request.GardenType
            };
            var updated = await _gardenService.UpdateGarden(id, garden);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGarden([FromRoute] int id)
        {
            var deleted = await _gardenService.DeleteGarden(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
