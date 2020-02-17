using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Identifier { get; set; }
        public string Nickname { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AvatarPath { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
