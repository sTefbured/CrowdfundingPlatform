using CrowdfundingPlatform.Models;
using CrowdfundingPlatform.Repositories;
using CrowdfundingPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly string defaultAvatarPath;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly GoogleDriveRepository googleDriveRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository, UserManager<ApplicationUser> userManager, GoogleDriveRepository googleDriveRepository,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.googleDriveRepository = googleDriveRepository;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
            defaultAvatarPath = googleDriveRepository
                   .GetImageLink("1mHrI0r8-nvveYI8j53MdHDecYTVIeVk9");
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
                    RegistrationDate = DateTime.Now,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    AvatarPath = UploadAvatar(registerViewModel.Avatar)
                };

                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
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

        private string UploadAvatar(IFormFile avatarFile)
        {
            string avatarPath = defaultAvatarPath;

            if (avatarFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + avatarFile.FileName;
                avatarPath = googleDriveRepository
                    .GetImageLink(googleDriveRepository
                    .UploadFIle(fileName, avatarFile.OpenReadStream()));
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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {            
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, 
                    loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
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
        
        [Route("~/user/{id}")]
        public IActionResult UserAccount(string id)
        {
            var viewModel = new UserAccountViewModel
            {
                UserToShow = userRepository.GetById(id)
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

        [HttpGet]
        [Authorize()]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string returnUrl)
        {
            if (User.IsInRole("Administrator"))
            {
                var userToDelete = await userManager.FindByIdAsync(id);
                var avatarPath = userToDelete.AvatarPath;
                if (avatarPath != null && avatarPath != defaultAvatarPath)
                {
                    try
                    {
                        googleDriveRepository.DeleteFile(userToDelete.AvatarPath);
                    }
                    catch (Google.GoogleApiException)
                    {

                    };
                }

                var result = await userManager.DeleteAsync(userToDelete);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("index", "home");
        }
    }
}
