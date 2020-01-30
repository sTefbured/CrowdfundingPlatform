using CrowdfundingPlatform.Data.Models;
using CrowdfundingPlatform.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Data.Mocks
{
    public class MockCampaign : ICampaignRepository
    {
        private readonly ICategoryRepository categoryRepository = new MockCategory();
        public IEnumerable<Campaign> Campaigns
        {
            get
            {
                return new HashSet<Campaign>
                {
                    new Campaign
                    {
                        Name = "RoX",
                        Category = categoryRepository.Categories.ElementAt(0),
                        ShortDescription = "Rock it with rockets!",
                        FullDescription = "RoX is not just another startup with ambicious goals. RoX is a bunch of people addicted to space, rocketry and spacecrafts. We currently develop our spacecraft, the main aim of which is reusability. Our ideal goal is to successfully bring our test cargo to low Earth orbit and catch the first stage of our rocket.",
                        RegistrationDate = new DateTime(2020, 1, 30),
                        GoalDate = new DateTime(2023, 1, 30),
                        MoneyEarned = 200,
                        MoneyGoal = 1000000
                    },
                    new Campaign
                    {
                        Name = "CallB",
                        Category = categoryRepository.Categories.ElementAt(2),
                        ShortDescription = "Useless here - useful there.",
                        FullDescription = "Another bussiness startup. Nothing interesting.",
                        RegistrationDate = new DateTime(2019, 1, 30),
                        GoalDate = new DateTime(2021, 1, 30),
                        MoneyEarned = 2000,
                        MoneyGoal = 100000
                    }
                };
            }
        }

        public Campaign getById(int id)
        {
            return Campaigns.ElementAt(id);
        }
    }
}
