using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> Users { get; }

        ApplicationUser GetById(string id);
    }
}
