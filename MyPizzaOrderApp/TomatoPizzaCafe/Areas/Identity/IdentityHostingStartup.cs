using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TomatoPizzaCafe.Models;

[assembly: HostingStartup(typeof(TomatoPizzaCafe.Areas.Identity.IdentityHostingStartup))]
namespace TomatoPizzaCafe.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TomatoPizzaCafeContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<MyIdentityContext>();
            });
        }
    }
}