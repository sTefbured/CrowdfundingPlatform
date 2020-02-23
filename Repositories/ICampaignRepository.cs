using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Repositories
{
    public interface ICampaignRepository
    {
        IEnumerable<Campaign> Campaigns { get; }
        Campaign GetById(int id);
        Campaign Add(Campaign campaign);
        Campaign Delete(int id);
    }
}
