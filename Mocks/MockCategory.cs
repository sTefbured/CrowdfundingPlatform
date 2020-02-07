using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Mocks
{
    public class MockCategory : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category
                    {
                        Name = "Rocketry",
                        Description = "Everything connected with rockets and flights to space."
                    },
                    new Category
                    {
                        Name = "Information technology",
                        Description = "Computer-based information systems: software and hardware."
                    },
                    new Category
                    {
                        Name = "Business",
                        Description = "Commercial activities."
                    }
                };
            }
        }
    }
}
