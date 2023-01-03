using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationMonitor.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StationMonitor.Entidades;

namespace StationMonitor
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("StationContext")));
            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                })
               
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSession(config => {
                

            });

            #region Facebook
            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    //facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //    //facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //    facebookOptions.AppId = "315705422240119";
            //    facebookOptions.AppSecret = "c90e3d931a9da3602491f8554f197cbb";

            //    //"Authentication:Facebook:AppId": "315705422240119",
            //    //"Authentication:Facebook:AppSecret": "c90e3d931a9da3602491f8554f197cbb",

            //});
            #endregion

            #region Google
            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{

            //    //googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
            //    //googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    googleOptions.ClientId = "896856668663-0aaghtosiik7tadedgljirv1sl7vgepg.apps.googleusercontent.com";
            //    googleOptions.ClientSecret = "25e9DhZbEkMHybkH8aIeFdN7";

            //    //"Authentication:Google:ClientId": "896856668663-0aaghtosiik7tadedgljirv1sl7vgepg.apps.googleusercontent.com",
            //    //"Authentication:Google:ClientSecret": "25e9DhZbEkMHybkH8aIeFdN7",

            //});
            #endregion

            #region Linkedin
            ////services.AddAuthentication().AddOAuth("LinkedIn",
            ////c =>
            ////{
            ////    c.ClientId =     Configuration["Authentication:Linkedin:ClientId"];
            ////    c.ClientSecret = Configuration["Authentication:Linkedin:ClientSecret"];


            ////"Authentication:Linkedin:ClientId": "1",
            ////"Authentication:Linkedin:ClientSecret": "1"


            ////    c.Scope.Add("r_basicprofile");
            ////    c.Scope.Add("r_emailaddress");
            ////    c.CallbackPath = "/signin-linkedin";
            ////    c.AuthorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
            ////    c.TokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
            ////    c.UserInformationEndpoint = "https://api.linkedin.com/v1/people/~:(id,formatted-name,email-address,picture-url)";
            ////    c.Events = new OAuthEvents
            ////    {
            ////        OnCreatingTicket = async context =>
            ////        {
            ////            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            ////            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
            ////            request.Headers.Add("x-li-format", "json");

            ////            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
            ////            response.EnsureSuccessStatusCode();
            ////            var user = JObject.Parse(await response.Content.ReadAsStringAsync());

            ////            var userId = user.Value<string>("id");
            ////            if (!string.IsNullOrEmpty(userId))
            ////            {
            ////                context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
            ////            }

            ////            var formattedName = user.Value<string>("formattedName");
            ////            if (!string.IsNullOrEmpty(formattedName))
            ////            {
            ////                context.Identity.AddClaim(new Claim(ClaimTypes.Name, formattedName, ClaimValueTypes.String, context.Options.ClaimsIssuer));
            ////            }

            ////            var email = user.Value<string>("emailAddress");
            ////            if (!string.IsNullOrEmpty(email))
            ////            {
            ////                context.Identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String,
            ////                    context.Options.ClaimsIssuer));
            ////            }
            ////            var pictureUrl = user.Value<string>("pictureUrl");
            ////            if (!string.IsNullOrEmpty(pictureUrl))
            ////            {
            ////                context.Identity.AddClaim(new Claim("profile-picture", pictureUrl, ClaimValueTypes.String,
            ////                    context.Options.ClaimsIssuer));
            ////            }
            ////        }
            ////    };

            ////});
            #endregion

            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
