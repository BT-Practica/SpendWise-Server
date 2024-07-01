using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.UserDtos
{
    public class UserForgotPasswordDTO
    {
        [Required]
        public string email{get; set;}
        [Required]
        public string password{get; set;}
    }
}