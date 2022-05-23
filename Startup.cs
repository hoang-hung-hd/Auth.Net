using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.ExtendMethods;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
         public static string contentRootPath {set;get;}
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            contentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>{
                string connectString = Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectString);
            });

            services.AddOptions();
            var mailsetting = Configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailsetting);
            services.AddSingleton<IEmailSender, SendMailService>();

            // Dang ky Identity ( sử dụng Razor page mặc định của Identity.UI)
            services.AddIdentity<AppUser , IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            
            // Truy cập IdentityOptions
            services.Configure<IdentityOptions> (options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 3; // Thất bại 3 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất
            

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
                options.SignIn.RequireConfirmedAccount = true; 
                
            });  

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/login/";
                options.LogoutPath = "/logout/";
                options.AccessDeniedPath = "/khongduoctruycap.html";
            });  

            services.AddAuthentication()
                    .AddGoogle(options => {
                        var gconfig = Configuration.GetSection("Authentication:Google");
                        options.ClientId = gconfig["ClientId"];
                        options.ClientSecret = gconfig["ClientSecret"];
                        // https://localhost:5001/signin-google
                        options.CallbackPath =  "/dang-nhap-tu-google";
                    })
                    .AddFacebook(options => {
                        var fconfig = Configuration.GetSection("Authentication:Facebook");
                        options.AppId  = fconfig["AppId"];
                        options.AppSecret = fconfig["AppSecret"];
                        options.CallbackPath =  "/dang-nhap-tu-facebook";
                    })
                    // .AddTwitter()
                    // .AddMicrosoftAccount()
                    ;

                    
            services.AddControllersWithViews();
            services.AddRazorPages();

            /*
            Thiet lap View luu theo cac thu muc rieng nhu duoi, trong do :
            {0} : Ten Action
            {1} : Ten Controller
            {2} : Teen Area
            */
            services.Configure<RazorViewEngineOptions>(options =>{
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddSingleton<ProductService>();
            services.AddSingleton<PlanetService>();
            services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.AddStatusCodePage();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "product",
                    areaName : "product",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                
                endpoints.MapRazorPages();
            });
        }
    }
}
