using CrowdfundingPlatform.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class CreateCampaignViewModel
    {
        [Required]
        public Campaign Campaign { get; set; }
        public IFormFile Image { get; set; }
    }
}
