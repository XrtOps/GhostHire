using System.ComponentModel.DataAnnotations;

namespace GhostHire.Models
{
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public decimal Price { get; set; }

        [Required]
        public string Categories { get; set; }

        public string PhotoFileNames { get; set; }
    }
}