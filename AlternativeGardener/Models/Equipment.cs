using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlternativeGardener.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        [StringLength(100)]
        public string Supplier { get; set; } = string.Empty;

        // Navigation Prop to associate Equipment with a User
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        // Navigation Prop to associate Equipment with a Garden
        public int? GardenId { get; set; }  

    }
}
