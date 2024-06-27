using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs.Income_CategoryDtos
{
    public class Income_CategoryDto
    {
        /*        [Key]
                public int Id { get; set; }*/
        [Required]
        public string? Name { get; set; }
        /*        public ICollection<Incomes> Incomes { get; set; } = [];*/
    }
}
