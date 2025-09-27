using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlternativeGardener.Services.Interfaces;
using AlternativeGardener.Models; // added for Garden model

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

        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Garden/Create.cshtml"); // Views/Garden/Create.cshtml
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Garden garden)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Garden/Create.cshtml", garden);
            }
            var created = await _gardenService.CreateGardenAsync(garden);
            if (created == null)
            {
                return Unauthorized();
            }
            return RedirectToAction(nameof(Index));
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