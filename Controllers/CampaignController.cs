using CrowdfundingPlatform.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CampaignController(ICampaignRepository campaignRepository, ICategoryRepository categoryRepository)
        {
            _campaignRepository = campaignRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult CampaignsList()
        {
            var campaigns = _campaignRepository.Campaigns;
            return View(campaigns);
        }
    }
}
