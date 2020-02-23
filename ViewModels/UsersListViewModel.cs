using CrowdfundingPlatform.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } 
    }
}
