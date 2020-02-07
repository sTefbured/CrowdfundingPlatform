using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundingPlatform.Models;

namespace CrowdfundingPlatform.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => appDbContext.Categories;
    }
}
