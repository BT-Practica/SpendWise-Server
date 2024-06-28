using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs
{
    public class UserLoginDTO
    {

        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}