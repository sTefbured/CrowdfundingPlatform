using CrowdfundingPlatform.Data.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;

        public HomeController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public ViewResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                FavoriteCampaigns = _campaignRepository.Campaigns.Where(campaign => campaign.IsPopular)
            };
            return View(homeIndexViewModel);
        }

        [Route("~/About")]
        public ViewResult About()
        {
            return View();
        }
    }
}
