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
        public string? GardenLocation { get; set; }
        public string? GardenSize { get; set; }
        public string? GardenType { get; set; }


        // Identity User Foreign Key
        public AppUser? User { get; set; }

        // Navigation Properties
        public List<Plant>? Plants { get; set; }
        public List<Equipment>? EquipmentList { get; set; }

    }
}
