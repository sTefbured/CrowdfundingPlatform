using CrowdfundingPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class CategoriesListViewModel
    {
        public ISet<Category> Categories { get; set; }
    }
}
