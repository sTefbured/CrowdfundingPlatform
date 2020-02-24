using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Contribution> Contributions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole[]
                    {
                        new IdentityRole
                        {
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },

                        new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        }
                    }
                );

            builder.Entity<Contribution>().HasOne(contribution => contribution.Campaign)
                                          .WithMany(campaign => campaign.Contributions)
                                          .HasForeignKey(contribution => contribution.CampaignId);

            builder.Entity<Contribution>().HasOne(contribution => contribution.Contributor)
                                          .WithMany(contributor => contributor.Contributions)
                                          .HasForeignKey(contribution => contribution.ContributorId);
            //builder.Entity<ApplicationUser>().HasData(
            //        new ApplicationUser[]
            //        {
            //            new ApplicationUser
            //            {
            //                UserName = "admin@crowdio.net",
            //                NormalizedUserName = "ADMIN@CROWDIO.NET",
            //                Email = "admin@crowdio.net",
            //                NormalizedEmail = "admin@crowdio.net",
            //                DateOfBirth = DateTime.Parse("09.11.2000"),
            //                EmailConfirmed = true,
            //                Nickname = "Administrator",
            //                RegistrationDate = DateTime.Now
            //            }
            //        }
            //    );
        }
    }
}
