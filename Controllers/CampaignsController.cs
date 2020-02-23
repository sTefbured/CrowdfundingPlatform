using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Repositories;
using CrowdfundingPlatform.ViewModels;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CampaignsController(ICampaignRepository campaignRepository, UserManager<ApplicationUser> userManager)
        {
            _campaignRepository = campaignRepository;
            this.userManager = userManager;
        }

        public ViewResult List()
        {
            CampaignsListViewModel viewModel = new CampaignsListViewModel
            {
                Campaigns = _campaignRepository.Campaigns
            };           
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
        public async Task<IActionResult> Create(Campaign campaign)
        {
            campaign.User = await userManager.GetUserAsync(User);
            //campaign.UserId = campaign.User.Id;
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
            var model = new SearchViewModel() 
            {
                Query = query
            };            
            if (string.IsNullOrEmpty(query))
            {
                model.Campaigns = _campaignRepository.Campaigns;
            }
            else
            {
                model.Campaigns = _campaignRepository.Campaigns
                    .FullTextSearchQuery(query, null).AsEnumerable();
            }
            
            return View(model);
        }
    }
}
