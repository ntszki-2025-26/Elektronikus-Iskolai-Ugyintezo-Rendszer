using Elektronikus_Iskolai_Ugyintezo_Rendszer.Components;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddMudServices();
            builder.Services.AddRazorComponents();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<ITaskService, TaskService>();

            builder.Services.AddSingleton<RequestService>();


            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AbsenceService>();
            builder.Services.AddScoped<GetRequestService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


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
            


            builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddMudServices();
            builder.Services.AddScoped<UserManagementService>();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await db.Database.MigrateAsync();
                await DbSeeder.SeedAsync(db);
            }

            app.UseStatusCodePagesWithReExecute("/not-found", "?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();


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