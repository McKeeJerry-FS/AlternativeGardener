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
    }
}