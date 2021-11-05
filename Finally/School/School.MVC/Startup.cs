using AutoMapper;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using School.BLL.Extensions;
using School.DAL.EF.Contexts;
using School.DAL.EF.Extensions;
using School.MVC.Configuration;
using School.MVC.Filters;
using School.MVC.Mapper;
using School.MVC.Middleware;
using System;

namespace School.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AcademyContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true; options.User.RequireUniqueEmail = true; })
                .AddDefaultUI()
                .AddEntityFrameworkStores<AcademyContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options => options.Filters.Add<GlobalExceptionFilter>());
            services.AddElmah();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddBusinessLogicServicesFromDalEF();
            services.AddBusinessLogicServicesFromBLL();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<SecurityOptions>(
                   Configuration.GetSection(SecurityOptions.SectionTitle));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseElmah();
        }       
    }
}