using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AuthenticationAndAuthorization.Data;
using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DevZH.AspNetCore.Authentication.WeChat;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace AuthenticationAndAuthorization
{
    public class Startup
    {
        string _testSecret = null;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            _testSecret = Configuration["MySecret"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(
                option =>
                {
                    option.Password.RequireDigit = true;
                    option.Password.RequiredLength = 8;
                    option.Password.RequireNonAlphanumeric = true;
                    option.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                //options.SslPort = 44325;
                //options.Filters.Add(new RequireHttpsAttribute());
            });
            services.AddCors(options=> 
            {
                options.AddPolicy("AllowSpecificOrigin",builder=> 
                {
                    builder.WithOrigins("http://fakedomain.com");
                });
            });
            //配置全局的过滤器
            services.Configure<MvcOptions>(cfg=> 
            {
                cfg.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
            services.AddAuthorization(cfg=> 
            {
                //两种写法灵活控制Claim相关的用户
                //cfg.AddPolicy("DoctorsOnly", policyBuilder => policyBuilder.RequireClaim("DoctorCred"));
                cfg.AddPolicy("DoctorsOnly", policyBuilder => policyBuilder.RequireClaim("DoctorCred","123456","1234567"));
            });
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();
            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions
            {
                ClientId = Configuration["Authentication:Microsoft:ClientId"],
                ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"]
            });

            app.UseTwitterAuthentication(new TwitterOptions
            {
                ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"],
                ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"]
            });

            app.UseGitHubAuthentication(new AspNet.Security.OAuth.GitHub.GitHubAuthenticationOptions
            {
                ClientId = Configuration["Authentication:Github:ClientId"],
                ClientSecret=Configuration["Authentication:Github:ClientSecret"]
            });

            //app.Run(async (context) =>
            //{
            //    byte[] res = Encoding.UTF8.GetBytes($"result is {_testSecret}");
            //    await context.Response.Body.WriteAsync(res, 0, res.Length);
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCors("AllowSpecificOrigin");
        }
    }
}
