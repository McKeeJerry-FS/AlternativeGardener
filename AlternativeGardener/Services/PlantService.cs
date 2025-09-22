using AlternativeGardener.Data;
using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AlternativeGardener.Services
{
    public class PlantService : IPlantService
    {
        public readonly ApplicationDbContext _db;
        public readonly UserManager<AppUser> _userManager;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public PlantService(ApplicationDbContext db, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        private async Task<AppUser?> GetCurrentUserAsync()
        {
            var httpCtx = _httpContextAccessor.HttpContext;
            if (httpCtx == null)
            {
                return await Task.FromResult<AppUser?>(null);
            }

            return await _userManager.GetUserAsync(httpCtx.User);
        }

       

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            var user = GetCurrentUserAsync();
            if (user == null)
            {
                return await Task.FromResult<List<Plant>>(new List<Plant>());
            }
            return await Task.FromResult<List<Plant>>(new List<Plant>());
        }

        public async Task<Plant> GetPlantByIdAsync(int Id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new Plant();
            }
            return new Plant();
        }

        public async Task<Plant?> CreatePlantAsync(Plant? plant)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            
            plant = new Plant
            {
                
            };
            plant.AppUser = user;
            _db.Plants.Add(plant);
            await _db.SaveChangesAsync();
            return plant;
        }

        public async Task<Plant?> UpdatePlantAsync(Plant plant)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            _db.Plants.Update(plant);
            await _db.SaveChangesAsync();
            return plant;

        }

        public async Task<bool> DeletePlantAsync(int Id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return false;
            }
            var existingPlant = _db.Plants
                .FirstOrDefault(p => p.Id == Id && p.AppUser != null && p.AppUser.Id == user.Id);
            if (existingPlant == null)
                {
                return false;
            }
            _db.Plants.Remove(existingPlant);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}
