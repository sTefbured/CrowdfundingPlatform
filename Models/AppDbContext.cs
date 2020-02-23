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

            builder.Entity<Campaign>().HasOne(p => p.User).WithMany(b => b.Campaigns);
        }
    }
}
