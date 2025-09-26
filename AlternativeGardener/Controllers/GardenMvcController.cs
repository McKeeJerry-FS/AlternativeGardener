using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlternativeGardener.Services.Interfaces;

namespace AlternativeGardener.Controllers
{
    [Authorize]
    public class GardenMvcController : Controller
    {
        private readonly IGardenService _gardenService;
        public GardenMvcController(IGardenService gardenService) => _gardenService = gardenService;

        public async Task<IActionResult> Index()
        {
            var gardens = await _gardenService.GetAllGardensAsync();
            return View("~/Views/Garden/Index.cshtml", gardens); // Views/Garden/Index.cshtml
        }

        public async Task<IActionResult> Details(int id)
        {
            var garden = await _gardenService.GetGardenById(id);
            if (garden == null)
            {
                return NotFound();
            }
            return View("~/Views/Garden/Details.cshtml", garden); // Views/Garden/Details.cshtml
        }

        public async Task<IActionResult> Create()
        {
            return View("~/Views/Garden/Create.cshtml"); // Views/Garden/Create.cshtml
        }

        public async Task<IActionResult> Edit(int id)
        {
            var garden = await _gardenService.GetGardenById(id);
            if (garden == null)
            {
                return NotFound();
            }
            return View("~/Views/Garden/Edit.cshtml", garden); // Views/Garden/Edit.cshtml
        }

        public async Task<IActionResult> Delete(int id)
        {
            var garden = await _gardenService.GetGardenById(id);
            if (garden == null)
            {
                return NotFound();
            }
            return View("~/Views/Garden/Delete.cshtml", garden); // Views/Garden/Delete.cshtml
        }

    }
}