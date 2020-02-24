using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Repositories;
using CrowdfundingPlatform.ViewModels;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IContributionRepository contributionRepository;
        private readonly GoogleDriveRepository googleDriveRepository;
        private readonly string defaultImagePath;

        public CampaignsController(ICampaignRepository campaignRepository, 
            UserManager<ApplicationUser> userManager, IContributionRepository contributionRepository,
            GoogleDriveRepository googleDriveRepository)
        {
            _campaignRepository = campaignRepository;
            this.userManager = userManager;
            this.contributionRepository = contributionRepository;
            this.googleDriveRepository = googleDriveRepository;
            defaultImagePath = googleDriveRepository.GetImageLink("1hwvAYuUsMmBhXPpdx5stq3uT9IMyAY95");
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
        public async Task<IActionResult> Create(CreateCampaignViewModel model)
        {
            var campaign = model.Campaign;
            campaign.ImageGalleryUrl = UploadImage(model.Image);
            campaign.Creator = await userManager.GetUserAsync(User);
            _campaignRepository.Add(campaign);
            return RedirectToAction("campaign", new { Id = campaign.Id });
        }

        private string UploadImage(IFormFile imageFile)
        {
            string imagePath = defaultImagePath;

            if (imageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + imageFile.FileName;
                imagePath = googleDriveRepository
                    .GetImageLink(googleDriveRepository
                    .UploadFIle(fileName, imageFile.OpenReadStream()));
            }
            return imagePath;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var campaign = _campaignRepository.Campaigns.First(campaign => campaign.Id == id);
            if (userManager.GetUserId(User) != campaign.Creator.Id)
            {
                return RedirectToAction("index", "home");
            }
            var imagePath = campaign.ImageGalleryUrl;
            if (imagePath != null && imagePath != defaultImagePath)
            {
                try
                {
                    googleDriveRepository.DeleteFile(campaign.ImageGalleryUrl);
                }
                catch (Google.GoogleApiException)
                {

                };
            }
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

        [HttpGet]
        [Authorize]
        public IActionResult Contribute(int id)
        {
            //var model = new Contribution
            //{
            //    Campaign = _campaignRepository.GetById(id),
            //    CampaignId = id,
            //    Contributor = await userManager.GetUserAsync(User),
            //    ContributorId = userManager.GetUserId(User)
            //};
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Contribute(Contribution contribution)
        {
            //contribution.ContributionId = Guid.NewGuid().ToString();
            //contribution.Campaign = _campaignRepository.GetById(contribution.CampaignId);
            //contribution.Contributor = await userManager.GetUserAsync(User);
            //contributionRepository.Add(contribution);
            return Redirect("~/campaigns/contribute/success/id=" + contribution.ContributionId);
        }

        [Authorize]
        [Route("~/campaigns/contribute/success/id={id}")]
        public IActionResult ContributionSuccess(string id)
        {
            var contribution = contributionRepository.GetById(id);
            return View(contribution);
        }

        public IActionResult Contribution(string id)
        {
            return View();
        }
    }
}
