using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class CampaignsListViewModel
    {
        public IEnumerable<Campaign> Campaigns { get; set; }
        public string CurrentCategory { get; set; }
    }
}
