using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlternativeGardener.Models
{
    public class WaterChem
    {
        [Key]
        public int WaterChemRecordId { get; set; }
        [Required]
        [Display(Name = "Test Date")]
        public DateTime TestDate { get; set; }
        [Display(Name = "pH Level")]
        public float PHLevel { get; set; }
        [Display(Name = "Hardness (ppm)")]
        public int Hardness { get; set; }
        [Display(Name = "Chlorine (ppm)")]
        public float Chlorine { get; set; }
        [Display(Name = "Other Notes")]
        [StringLength(1000)]
        public string Notes { get; set; } = string.Empty;
        // Navigation Prop to associate WaterChem with a User
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        // Navigation Prop to associate WaterChem with a Garden
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }

    }
}
