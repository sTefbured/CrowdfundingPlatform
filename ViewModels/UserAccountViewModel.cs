using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class UserAccountViewModel
    {
        public ApplicationUser UserToShow { get; set; }
        public bool IsCurrentUser { get; set; }
    }
}
