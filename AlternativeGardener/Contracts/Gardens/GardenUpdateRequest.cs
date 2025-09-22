using AlternativeGardener.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlternativeGardener.Contracts.Gardens
{
    public class GardenUpdateRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? GardenName { get; set; }
        public Location? GardenLocation { get; set; }
        public string? GardenSize { get; set; }
        public GardenType? GardenType { get; set; }
    }
}