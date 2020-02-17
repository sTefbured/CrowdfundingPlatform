using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "Nickname must contain only letters and/or numbers.")]
        [MinLength(5, ErrorMessage = "Nickname must be at least 5 characters long.")]
        [MaxLength(20, ErrorMessage = "Nickname must not be longer than 20 caracters long.")]
        public string Nickname { get; set; }

        public IFormFile Avatar { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Remote(action: "IsTakenEmail", controller: "Account")]
        [RegularExpression(@".+@.+\..+$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters length.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password don't match.")]
        public string ConfirmPassword { get; set; }
    }
}
