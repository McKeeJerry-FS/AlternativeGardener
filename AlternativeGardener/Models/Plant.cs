using AlternativeGardener.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlternativeGardener.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PlantName { get; set; }
        public PlantType? PlantType { get; set; }
        public string? Species { get; set; }
        public DateTime DatePlanted { get; set; }
        public GrowthStatus GrowthStatus { get; set; }
        public string? Note { get; set; }
        public string? PlantDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? CareInstructions { get; set; }
        public bool IsPerennial { get; set; }
        public DateTime? LastWatered { get; set; }

        public DateTime? LastFertilized { get; set; }
        public DateTime? LastPruned { get; set; }
        public Location? Location { get; set; }
        public string? SunlightRequirements { get; set; }
        public string? SoilType { get; set; }
        public string? WateringSchedule { get; set; }
        public string? FertilizingSchedule { get; set; }
        public string? PruningSchedule { get; set; }
        public string? PestControlNotes { get; set; }
        public string? DiseaseControlNotes { get; set; }

        // Navigation property to link to the user who owns this plant
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        // Navigation property to link plant to a garden
        [ForeignKey("Garden")]
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }

    }
}
