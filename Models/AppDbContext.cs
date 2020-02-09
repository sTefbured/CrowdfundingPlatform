using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Campaign> Campaigns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Campaign>().HasData(
                new Campaign
                {
                    Id = 1,
                    Name = "RoX",
                    ShortDescription = "Rock it, RoX's rockets!",
                    FullDescription = "RoX is a bunch of people with a fantastic idea: bringing humanity to outer planets.",
                    MoneyGoal = 1000000,                    
                    GoalDate = new DateTime(2025, 9, 9),
                }
            );
        }
    }
}
