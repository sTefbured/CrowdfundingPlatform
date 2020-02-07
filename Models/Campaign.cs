using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters")]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Maximum length is 1000 characters")]
        public string FullDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required]
        public DateTime GoalDate { get; set; }
        public double MoneyEarned { get; set; }
        [Required]
        public double MoneyGoal { get; set; }
        public bool IsPopular { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public string ImageGalleryUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}