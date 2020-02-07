using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Data.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public readonly AppDbContext appDbContext;

        public CampaignRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Campaign> Campaigns => appDbContext.Campaigns.Include(c => c.Category);

        public Campaign GetById(int id)
        {
            return appDbContext.Campaigns.Find(id);
        }
    }
}
