using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlternativeGardener.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Notes")]
        [StringLength(1000)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation Prop to associate Record with a User
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        
        // Navigation Prop to associate Record with a Garden
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }
        
        // Navigation Prop to associate Record with Plants
        public IEnumerable<Plant>? Plants { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }


    }
}
