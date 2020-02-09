using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [RegularExpression(@".+@.+\..+$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
