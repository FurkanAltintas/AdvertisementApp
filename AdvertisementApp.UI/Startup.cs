using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.Business.Helpers;
using AdvertisementApp.UI.Mappings.AutoMapper;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules.FluentValidation;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
            services.AddControllersWithViews();

            #region Cookie Configuration
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.Cookie.Name = "AdvertisementCookie";
                opt.Cookie.HttpOnly = true; // ClientSide Scriptlerden korumamýzý saðlar
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; // Cookieyi paylaþýmlardan korur
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); // 20 gün hayatta kalýcak
                opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
                opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
            });
            #endregion

            #region AutoMapper Configuration
            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            profiles.Add(new AdvertisementAppUserProfile());
            profiles.Add(new UserInfoProfile());


            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
