namespace AlternativeGardener.Services.Interfaces
{
    using AlternativeGardener.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGardenService
    {
        Task<List<Garden>> GetAllGardensAsync();
        Task<Garden> GetGardenById(int Id);
        Task<Garden?> CreateGardenAsync(Garden garden);
        Task<Garden?> UpdateGarden(int Id, Garden garden);
        Task<bool> DeleteGarden(int Id);

    }
}
