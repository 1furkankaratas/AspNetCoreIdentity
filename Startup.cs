using AspNetCoreIdentity.CustomValidation;
using AspNetCoreIdentity.Models;
using AspNetCoreIdentity.Requirements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity
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

            services.AddTransient<IAuthorizationHandler, ExpireDateExchangeHandler>();

            //Veritabanı bağlantı ayarları
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("AnkaraPolicy", policy =>
                {
                    policy.RequireClaim("city", "ankara");
                });
                opts.AddPolicy("violencePolicy", policy =>
                {
                    policy.RequireClaim("violence");
                });

                opts.AddPolicy("expireDateExchange", policy =>
                {
                    policy.AddRequirements(new ExpireDateExchangeRequirement());
                });
            });


            //Identity'i projeye dahil etme ve gerekli paramatrelerin verilmesi
            services.AddIdentity<AppUser, AppRole>(opts =>
            {
                //Identity Doğrulama ayarlamaları
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;

                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";

            }).AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();


            CookieBuilder cookieBuilder = new CookieBuilder();

            cookieBuilder.Name = "MySite";
            cookieBuilder.HttpOnly = false;
            //cross site request
            cookieBuilder.SameSite = SameSiteMode.Lax;
            //Http isteklerini karsılama ayarı https/http
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;


            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Home/LogIn");
                opts.LogoutPath = new PathString("/Home/Index");
                opts.AccessDeniedPath = new PathString("/Home/LogIn");
                opts.Cookie = cookieBuilder;
                //Cookie ömrünü yeniler
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);
                opts.AccessDeniedPath = new PathString("/Member/AccessDenied");

            });

            services.AddScoped<IClaimsTransformation, ClaimProvider.ClaimProvider>();
            // Mvc projeye dahil etme
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app)
        {
            //Sayfada hata aldığımızda açıklayıcı bilgiler göstermeye yarıyor.
            app.UseDeveloperExceptionPage();
            //İçerik dönmeyen sayfalarda bize bilgilendirici yazılar döndürüyor.
            app.UseStatusCodePages();
            // wwwroot klasörünü etkinleştirir
            app.UseStaticFiles();

            app.UseAuthentication();
            // route şeması
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
