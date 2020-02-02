using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Data.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime GoalDate { get; set; }
        public double MoneyEarned { get; set; }
        public double MoneyGoal { get; set; }
        public bool IsPopular { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ISet<string> Tags { get; set; }
        public string ImageGalleryUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}