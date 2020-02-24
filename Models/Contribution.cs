using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Contribution
    {
        public string ContributionId { get; set; }
        [Required]
        public double Money { get; set; }
        public DateTime Time { get; set; }
        public string Commentary { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public string ContributorId { get; set; }
        public ApplicationUser Contributor { get; set; }
    }
}
