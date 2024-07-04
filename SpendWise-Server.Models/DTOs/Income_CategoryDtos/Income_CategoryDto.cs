using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs.Income_CategoryDtos
{
    public class Income_CategoryDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
