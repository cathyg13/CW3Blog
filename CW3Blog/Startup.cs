using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CW3Blog.Data;
using CW3Blog.Models;
using CW3Blog.Services;

namespace CW3Blog
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            {
                if (env.IsDevelopment())
                {
                    app.UseBrowserLink();
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }

                app.UseStaticFiles();

                app.UseAuthentication();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });

                createRoles(serviceProvider);
            }

        }
        private void createRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Task<IdentityResult> roleResult;

            //Check that there is a role and create if not
            string[] roleName = { "RCustomer", "RAdmin" };

            foreach (string r in roleName)
            {
                Task<bool> hasRole = roleManager.RoleExistsAsync(r);
                hasRole.Wait();

                if (!hasRole.Result)
                {
                    roleResult = roleManager.CreateAsync(new IdentityRole(r));
                    roleResult.Wait();
                }
            }

            //Check if the admin user exists and create it if not
            //Add to the Admin role
            string[] userName = { "Member1@email.com", "Customer1@email.com", "Customer2@email.com", "Customer3@email.com", "Customer4@email.com", "Customer5@email.com" };

            foreach (string u in userName)
            {
                Task<ApplicationUser> testUser = userManager.FindByNameAsync(u);
                testUser.Wait();

                if (testUser.Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.Email = u;
                    user.UserName = u;

                    Task<IdentityResult> newUser = userManager.CreateAsync(user, "Password123!");
                    newUser.Wait();

                    if (newUser.Result.Succeeded)
                    {

                        if (u.Contains("Member"))
                        {
                            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(user, "RAdmin");
                            newUserRole.Wait();
                        }

                        else
                        {
                            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(user, "RCustomer");
                            newUserRole.Wait();
                        }
                    }
                }

            }
        }
    }
}