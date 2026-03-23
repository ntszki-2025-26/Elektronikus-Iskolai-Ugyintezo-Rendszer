using Elektronikus_Iskolai_Ugyintezo_Rendszer.Components;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Alap szolgáltatások hozzáadása
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Egyedi szolgáltatások regisztrálása
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AbsenceService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            // HITELESÍTÉS ÉS JOGOSULTSÁGKEZELÉS BEÁLLÍTÁSA
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "auth_token";
                    options.LoginPath = "/Login";
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                    options.AccessDeniedPath = "/access-denied";
                });

            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();
            
            //builder.Services.AddHttpContextAccessor();

            // Adatbázis konfiguráció (DefaultConnection használatával)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            // HTTP kéréskezelési folyamat (Middleware)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", "?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // FONTOS: Az Antiforgery és a hitelesítés sorrendje
            app.UseAntiforgery();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}