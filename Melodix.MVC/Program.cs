using Melodix.Data;
using Melodix.Models.Models;
using Melodix.MVC.Services.Patterns.Adapter.SendGrid;
using Melodix.MVC.Services.SpotifyApis.Adapters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using AspNet.Security.OAuth.Spotify;

namespace Melodix.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddRazorPages();
            //builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();
            builder.Services.AddSingleton<IMailProvider, SendGridAdapter>();
            builder.Services.AddSingleton<IEmailSender, SendGridAdapter>();
            builder.Services.AddHttpClient<ISpotifyWebApiAdapter, SpotifyWebApiAdapter>();
            builder.Services.AddHttpClient<ISpotifyPlaybackSdkAdapter, SpotifyPlaybackSdkAdapter>();
            builder.Services.AddHttpClient<ISpotifyAdsApiAdapter, SpotifyAdsApiAdapter>();
            builder.Services.AddScoped<ISpotifyService, SpotifyService>();


            builder.Services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 15;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Spotify";
            })
            .AddCookie()
            .AddSpotify("Spotify", options =>
            {
                options.ClientId = "TU_CLIENT_ID";
                options.ClientSecret = "TU_CLIENT_SECRET";
                options.CallbackPath = "/callback"; // Debe coincidir con tu Redirect URI
                options.Scope.Add("user-read-playback-state");
                options.Scope.Add("user-modify-playback-state");
                options.Scope.Add("user-read-currently-playing");
                // Agrega más scopes si los necesitas
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
