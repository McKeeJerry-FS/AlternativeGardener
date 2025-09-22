using AlternativeGardener.Models;

namespace AlternativeGardener.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant> GetPlantByIdAsync(int Id);
        Task<Plant?> CreatePlantAsync(Plant plant);
        Task<Plant?> UpdatePlantAsync(Plant plant);
        Task<bool> DeletePlantAsync(int Id);

    }
}
