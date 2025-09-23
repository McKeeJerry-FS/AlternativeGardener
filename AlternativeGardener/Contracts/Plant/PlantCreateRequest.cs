using AlternativeGardener.Models;
using AlternativeGardener.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlternativeGardener.Contracts.Plant
{
    public class PlantCreateRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? PlantName { get; set; }
        public string? Species { get; set; }
        public PlantType? PlantType { get; set; }
        public DateTime? DatePlanted { get; set; }
        public string? Note { get; set; }
        public string? PlantDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? CareInstructions { get; set; }
        public bool? IsPerennial { get; set; }
        public DateTime? LastWatered { get; set; }
        public DateTime? LastFertilized { get; set; }
        public DateTime? LastPruned { get; set; }
        public int? GardenId { get; set; }
        public string? SunlightRequirements { get; set; }
        public string? SoilType { get; set; }
        public string? WateringSchedule { get; set; }
        public string? FertilizingSchedule { get; set; }
        public string? PruningSchedule { get; set; }
        public string? PestControlNotes { get; set; }
        public string? DiseaseControlNotes { get; set; } = null;
        public PlantCreateRequest() { }
        public PlantCreateRequest(string? plantName, PlantType? plantType, string? species, DateTime? datePlanted, string? note, string? plantDescription, string? imageUrl, string? careInstructions, bool? isPerennial, DateTime? lastWatered, DateTime? lastFertilized, DateTime? lastPruned, int? gardenId, string? sunlightRequirements, string? soilType, string? wateringSchedule, string? fertilizingSchedule, string? pruningSchedule, string? pestControlNotes, string? diseaseControlNotes)
        {
            PlantName = plantName;
            Species = species;
            DatePlanted = datePlanted;
            PlantType = plantType;
            Note = note;
            PlantDescription = plantDescription;
            ImageUrl = imageUrl;
            CareInstructions = careInstructions;
            IsPerennial = isPerennial;
            LastWatered = lastWatered;
            LastFertilized = lastFertilized;
            LastPruned = lastPruned;
            GardenId = gardenId;
            SunlightRequirements = sunlightRequirements;
            SoilType = soilType;
            WateringSchedule = wateringSchedule;
            FertilizingSchedule = fertilizingSchedule;
            PruningSchedule = pruningSchedule;
            PestControlNotes = pestControlNotes;
            DiseaseControlNotes = diseaseControlNotes;
        }
    }
}
