using CrowdfundingPlatform.Data.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICampaignRepository campaignRepository, ICategoryRepository categoryRepository)
        {
            _campaignRepository = campaignRepository;
            _categoryRepository = categoryRepository;
        }  

        public ViewResult List()
        {
            CategoriesListViewModel viewModel = new CategoriesListViewModel();
            viewModel.Categories = _categoryRepository.Categories;
            return View(viewModel);
        }
    }
}
