using System.ComponentModel.DataAnnotations;
using GhostHire.Validations;

namespace GhostHire.Models
{
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }

        
        [TitleValidation]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Enter your description!")]

        public string? Description { get; set; }

        [Required(ErrorMessage = "Enter your price!")]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Select the following categories!")]
        public string? Categories { get; set; }

        public string? PhotoFileNames { get; set; }
    }
}