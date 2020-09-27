using borsvarlden.Db;
using borsvarlden.Finwire;
using borsvarlden.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.WebEncoders;

namespace borsvarlden
{
    using Services.Facebook;
    using Services.Entities;
    using Services.Finwire;
    using Services.Azure;

    public class Startup
    {
        private static readonly string _databaseConnectionStringName = "borsvarlden";

        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(_databaseConnectionStringName)));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });

            //Skips authorization in development mode.
            services.AddAuthorization(x =>
            {
                if (_environment.IsDevelopment())
                {
                    x.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .RequireAssertion(_ => true)
                        .Build();
                }
            });

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            services.AddMvc();
            services.AddScoped<IFinwireParserService, FinwireFileParserService>();
            services.AddScoped<IFinwireNewsService, FinwireNewsService>();
            services.AddScoped<IFinwireFilterService,FinwireFilterService>();
            services.AddScoped<IConfigurationHelper, ConfigurationHelper>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IFinwireXmlNewsService, FinwireXmlNewsService>();
            services.AddScoped<IFinwireCompaniesService, FinwireCompaniesService>();
            services.AddScoped<IFacebookService, FacebookService>();
            services.AddScoped<IAzureStorageImageService, AzureStorageImageService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
