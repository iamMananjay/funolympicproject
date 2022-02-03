using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfigurationRoot _config;
        //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        public Startup(IWebHostEnvironment env)
        {
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                       .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();
        }
        public IConfiguration Configuration { get; }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            IdentityResult roleResult, roleResult1;
            //Adding Addmin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var Admin =await UserManager.FindByEmailAsync("admin@gmail.com");
            if (Admin==null)
            {
                IdentityResult result;
                ApplicationUser Adminuser = new ApplicationUser();
                Adminuser.Id = Guid.NewGuid().ToString();
                Adminuser.FullName = "Admin";
                Adminuser.UserName = "admin";
                Adminuser.Email = "admin@gmail.com";
                Adminuser.PasswordHash = "Admin@123";
                Adminuser.Country = "Nepal";
                Adminuser.State = "Bagmati";
                Adminuser.IsActive = true;
                result = await UserManager.CreateAsync(Adminuser, Adminuser.PasswordHash);

                //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
                ApplicationUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
                var User = new ApplicationUser();
                await UserManager.AddToRoleAsync(user, "Admin");
            }
            
            

            var roleCheckEmp = await RoleManager.RoleExistsAsync("Employee");
            if (!roleCheckEmp)
            {
                //create the roles and seed them to the database  
                roleResult1 = await RoleManager.CreateAsync(new IdentityRole("Employee"));
            }

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton(_config);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<EmployeeManagementDbContext>();
            //services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
           // services.AddScoped(typeof(IEmployeeProvider), typeof(EmployeeProvider));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IApplicationUserProvider, ApplicationUserProvider>();
            services.AddScoped<IHolidayProvider, HolidayProvider>();
            services.AddScoped<ILeaveProvider, LeaveProvider>();


            //services.AddTransient<IEmailSender, EmailSender>(i =>
            //     new EmailSender(
            //         Configuration["EmailSender:Host"],
            //         Configuration.GetValue<int>("EmailSender:Port"),
            //         Configuration.GetValue<bool>("EmailSender:EnableSSL"),
            //         Configuration["EmailSender:UserName"],
            //         Configuration["EmailSender:Password"]
            //     )
            // );

            //services.RegisterServiceDependencies();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider services)
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //CreateUserRoles(services).Wait();
        }
    }
}
