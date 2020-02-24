using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly AppDbContext appDbContext;

        public CampaignRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Campaign> Campaigns => appDbContext
                                                  .Campaigns
                                                  .Include(campaign => campaign.Creator)
                                                  .AsEnumerable();

        public Campaign GetById(int id)
        {
            return Campaigns.Single(campaign => campaign.Id == id);
        }

        public Campaign Add(Campaign campaign)
        {
            campaign.RegistrationDate = DateTime.Now;
            appDbContext.Campaigns.Add(campaign);
            appDbContext.SaveChanges();
            return campaign;
        }

        public Campaign Delete(int id)
        {
            var campaign = appDbContext.Campaigns.First(element => element.Id == id);
            appDbContext.Campaigns.Remove(campaign);
            appDbContext.SaveChanges();
            return campaign;
        }
    }
}
