using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs
{
    public class UserLoginDTO
    {
        public int Id { get; set; }

        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}