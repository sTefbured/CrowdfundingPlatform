using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Data.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CampaignsController(ICampaignRepository campaignRepository, ICategoryRepository categoryRepository)
        {
            _campaignRepository = campaignRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            CampaignsListViewModel viewModel = new CampaignsListViewModel();
            viewModel.Campaigns = _campaignRepository.Campaigns;
            viewModel.CurrentCategory = "Rocketry";
            return View(viewModel);
        }

        [Route("~/campaigns/id={id}")]
        public ViewResult Campaign(int id)
        {
            Campaign campaign = _campaignRepository.GetById(id);
            return View(campaign);
        }
    }
}
