using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs.Incomes
{
    public class IncomesDto
    {
        /*        public int Id { get; set; }*/
        /*        public DateTime RegistrationDate { get; set; }*/
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Reccurence { get; set; }
        /*        [Required]
                public int UserId { get; set; }*/
        [Required]
        public int Income_CategoryId { get; set; }

    }
}
