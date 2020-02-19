using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public CampaignsController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public ViewResult List()
        {
            CampaignsListViewModel viewModel = new CampaignsListViewModel();
            viewModel.Campaigns = _campaignRepository.Campaigns;
            return View(viewModel);
        }

        [Route("~/campaigns/id={id}")]
        public ViewResult Campaign(int id)
        {
            Campaign campaign = _campaignRepository.GetById(id);
            return View(campaign);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Campaign campaign)
        {
            _campaignRepository.Add(campaign);
            return RedirectToAction("campaign", new { Id = campaign.Id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _campaignRepository.Delete(id);
            return RedirectToAction("List", "Campaigns");
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var model = new SearchViewModel();
            model.Query = query;
            query = query.ToLower();
            model.Campaigns = _campaignRepository
                              .Campaigns
                              .Where(camp =>
                                  camp.Name.ToLower().Contains(query)
                                  || camp.FullDescription.ToLower().Contains(query)
                                  || camp.ShortDescription.ToLower().Contains(query));

            return View(model);
        }
    }
}
