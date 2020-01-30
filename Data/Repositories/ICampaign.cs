using CrowdfundingPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Data.Repositories
{
    interface ICampaign
    {
        IEnumerable<Campaign> Campaigns { get; }
        Campaign getById(int id);
    }
}
