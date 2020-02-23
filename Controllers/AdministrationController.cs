using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


        public IActionResult UsersList()
        {
            var model = new UsersListViewModel
            {
                Users = userManager.Users
            };
            return View(model);
        }
    }
}
