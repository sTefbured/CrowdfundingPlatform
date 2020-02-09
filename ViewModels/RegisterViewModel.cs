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
