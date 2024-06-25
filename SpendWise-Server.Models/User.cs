using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [EmailAddress]
        [MaxLength(256)]
        [Required]
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
