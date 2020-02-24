using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Repositories
{
    public interface IContributionRepository
    {
        IEnumerable<Contribution> Contributions { get; }
        Contribution GetById(string id);
        Contribution Add(Contribution contribution);
    }
}
