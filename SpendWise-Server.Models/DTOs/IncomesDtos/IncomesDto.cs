using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs.Incomes
{
    public class IncomesDto
    {
        [Required]
        public int Amount {get; set;} 
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public bool Reccurence { get; set; }

    }
}
