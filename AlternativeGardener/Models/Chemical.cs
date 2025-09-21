using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlternativeGardener.Models
{
    public class Chemical
    {
        [Key]
        public int ChemicalId { get; set; }
        
        [Required]
        [Display(Name = "Chemical Name")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        [Display(Name = "Chemical Description")]
        public string Description { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        [StringLength(100)]
        public string Supplier { get; set; } = string.Empty;
        
        // Navigation Prop to associate Chemical with a User
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        
        // Navigation Prop to associate Chemical with a Garden
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }

    }
}
