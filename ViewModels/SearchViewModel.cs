using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<Campaign> Campaigns { get; set; }
        public string Query { get; set; }
    }
}
