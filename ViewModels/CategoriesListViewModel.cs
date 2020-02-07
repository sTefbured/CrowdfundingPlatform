using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.ViewModels
{
    public class CategoriesListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
