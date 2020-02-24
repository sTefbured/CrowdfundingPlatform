using CrowdfundingPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<ApplicationUser> Users => appDbContext
                                                     .Users
                                                     .Include(user => user.Campaigns)
                                                     .AsEnumerable();

        public ApplicationUser GetById(string id)
        {
            return Users.Single(user => user.Id == id);
        }
    }
}
