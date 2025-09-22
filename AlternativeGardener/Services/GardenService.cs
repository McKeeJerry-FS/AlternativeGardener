using AlternativeGardener.Data;
using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlternativeGardener.Services
{
    public class GardenService : IGardenService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GardenService(ApplicationDbContext db, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Garden>> GetAllGardensAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new List<Garden>();
            }

            return await _db.Gardens
                .Where(g => g.User != null && g.User.Id == user.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Garden?> CreateGardenAsync(Garden garden)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            garden.User = user;
            _db.Gardens.Add(garden);
            await _db.SaveChangesAsync();
            return garden;
        }

        private Task<AppUser?> GetCurrentUserAsync()
        {
            var httpCtx = _httpContextAccessor.HttpContext;
            if (httpCtx == null)
            {
                return Task.FromResult<AppUser?>(null);
            }

            return _userManager.GetUserAsync(httpCtx.User);
        }

        public async Task<Garden> GetGardenById(int Id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found.");
            }
            var garden = await _db.Gardens
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GardenID == Id && g.User != null && g.User.Id == user.Id);
            if (garden == null)
                {
                throw new KeyNotFoundException("Garden not found.");
            }
            return garden;
        }

        public Task<Garden?> UpdateGarden(int Id, Garden garden)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGarden(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
