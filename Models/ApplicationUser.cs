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
    }
}
