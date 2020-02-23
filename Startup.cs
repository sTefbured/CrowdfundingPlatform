using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundingPlatform.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrowdfundingPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Westwind.AspNetCore.Markdown;
using Markdig;

namespace CrowdfundingPlatform
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options
                .UseSqlServer(_configuration.GetConnectionString("CrowdIODBConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddMarkdown(config =>
            {
                config.ConfigureMarkdigPipeline = builder =>
                {
                    builder.UseEmphasisExtras(Markdig.Extensions.EmphasisExtras.EmphasisExtraOptions.Default)
                        .UsePipeTables()
                        .UseGridTables()
                        .UseAutoLinks()
                        .UseAbbreviations()
                        .UseYamlFrontMatter()
                        .UseEmojiAndSmiley(true)
                        .UseListExtras()
                        .UseFigures()
                        .UseTaskLists()
                        .UseCustomContainers()
                        .UseGenericAttributes()
                        .DisableHtml();
                };
            });
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddApplicationPart(typeof(MarkdownPageProcessorMiddleware).Assembly);
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<GoogleDriveRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMarkdown();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
