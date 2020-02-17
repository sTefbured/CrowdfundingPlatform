using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly GoogleDriveRepository googleDriveRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, GoogleDriveRepository googleDriveRepository, 
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.googleDriveRepository = googleDriveRepository;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Nickname = registerViewModel.Nickname,
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    Identifier = userManager.Users.Count() + 1,
                    RegistrationDate = DateTime.Now,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    AvatarPath = GetAvatarPath(registerViewModel)
                };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {                  
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerViewModel);
        }

        private string GetAvatarPath(RegisterViewModel registerViewModel)
        {
            string avatarFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
            string avatarPath = Path.Combine(avatarFolder, "defaultAvatar.png");

            if (registerViewModel.Avatar != null)
            {
                string fileName = Guid.NewGuid().ToString() +  registerViewModel.Avatar.FileName;
                avatarPath = googleDriveRepository
                    .GetImageLink(googleDriveRepository
                    .UploadFIle(fileName, registerViewModel.Avatar.OpenReadStream()));
            }
            return avatarPath;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {            
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, 
                    loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(loginViewModel);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsTakenEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            return Json($"{email} is already taken.");
        }
        
        [Route("~/user/{identifier}")]
        public IActionResult UserAccount(int identifier)
        {
            var viewModel = new UserAccountViewModel
            {
                UserToShow = userManager.Users.FirstOrDefault(user => user.Identifier == identifier)
            };

            if ((userManager.GetUserId(User) == viewModel.UserToShow.Id))
            { 
                viewModel.IsCurrentUser = true;
            } 
            else
            {
                viewModel.IsCurrentUser = false;
            }

            return View(viewModel);
        }
    }
}
