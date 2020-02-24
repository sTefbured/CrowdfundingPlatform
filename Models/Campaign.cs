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
        [Display(Name = "Short description")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Full description (Markdown is supported)")]
        [MaxLength(1000, ErrorMessage = "Maximum length is 1000 characters")]
        public string FullDescription { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime GoalDate { get; set; }

        public double MoneyEarned { get; set; }

        [Required]
        [Display(Name = "Money goal")]
        public double MoneyGoal { get; set; }

        public bool IsPopular { get; set; }

        [Display(Name = "Image")]
        public string ImageGalleryUrl { get; set; }

        public string VideoUrl { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public IEnumerable<Contribution> Contributions { get; set; }
    }
}