using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Campaign> FavoriteCampaigns { get; set; }
    }
}
