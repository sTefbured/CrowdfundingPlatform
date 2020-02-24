using CrowdfundingPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Repositories
{
    public class ContributionRepository : IContributionRepository
    {
        private readonly AppDbContext appDbContext;

        public ContributionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Contribution> Contributions => appDbContext
                                                          .Contributions
                                                          .Include(contribution => contribution.Campaign)
                                                          .Include(contribution => contribution.Contributor)
                                                          .AsEnumerable();

        public Contribution Add(Contribution contribution)
        {
            contribution.Time = DateTime.Now;
            appDbContext.Contributions.Add(contribution);
            appDbContext.SaveChanges();
            return contribution;
        }

        public Contribution GetById(string id)
        {
            return Contributions.Single(contribution => contribution.ContributionId == id);
        }
    }
}
