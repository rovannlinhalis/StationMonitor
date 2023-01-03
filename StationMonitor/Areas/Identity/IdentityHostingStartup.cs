using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StationMonitor.Data;
using StationMonitor.Entidades;

[assembly: HostingStartup(typeof(StationMonitor.Areas.Identity.IdentityHostingStartup))]
namespace StationMonitor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public IConfiguration Configuration { get; }

        public IdentityHostingStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                   Configuration.GetConnectionString("StationContext")));
                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();


                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("IntegraWebReportContextConnection")));

                //services.AddDefaultIdentity<WebUser>()
                //    .AddEntityFrameworkStores<IntegraWebReportContext>();
            });
        }
    }
}