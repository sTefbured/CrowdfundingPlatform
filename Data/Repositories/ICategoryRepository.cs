using CrowdfundingPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Data.Repositories
{
    public interface ICategoryRepository
    {
        ISet<Category> Categories { get; }
    }
}
