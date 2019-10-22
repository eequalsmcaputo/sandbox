﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Routing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // Static URL Syntax
                /*routes.MapRoute(
                    name: "",
                    template: "Literal/{controller}/{action}/{id?}",
                    defaults: new { controller = "home", action = "index" });*/

                // Alternative Syntax
                /*routes.MapRoute(
                    name: "",
                    template: "{controller}/{action}/{id?}/{*all}",
                    defaults: new { controller = "home", action = "index" });*/

                // Constraining Routes
                routes.MapRoute(
                    name: "default",
                    //template: "{controller=Home}/{action=Index}/{id:regex([0-9+$])?}");
                    //template: "{controller=Home}/{action=Index}/{id:alpha:minlength(2)?}");
                    template: "{controller=Home}/{action=Index}/{id?}");
                /*routes.MapRoute(
                    name: "",
                    template: "{controller}/{action}/{id?}/{*all}",
                    defaults: new { controller = "home", action = "index" },
                    constraints: new { id = new IntRouteConstraint() });*/
            });
        }
    }
}
