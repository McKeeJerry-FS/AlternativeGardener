using AlternativeGardener.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlternativeGardener.Models
{
    public class Garden
    {
        //Properties
        [Key]
        public int GardenID { get; set; }
        [Required]
        [Display(Name = "Garden Name")]
        [StringLength(50, ErrorMessage = "Garden name must be longer than 2 characters and cannot be longer than 50 characters.", MinimumLength = 2)]
        public string? GardenName { get; set; }
        public Location? GardenLocation { get; set; }
        public string? GardenSize { get; set; }
        public GardenType? GardenType { get; set; }


        // Identity User Foreign Key
        public AppUser? User { get; set; }

        // Navigation Properties
        public IEnumerable<Plant>? Plants { get; set; }
        //public IEnumerable<Equipment>? EquipmentList { get; set; }
        //public IEnumerable<Nutrient>? Nutrients { get; set; }
        //public IEnumerable<Chemical>? Chemicals { get; set; }

        //public IEnumerable<Record>? DailyRecords { get; set; }

    }
}
