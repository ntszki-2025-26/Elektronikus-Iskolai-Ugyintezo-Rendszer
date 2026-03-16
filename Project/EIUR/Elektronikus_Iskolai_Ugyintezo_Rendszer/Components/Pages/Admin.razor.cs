using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages
{
    public partial class Admin
    {
        [Inject] private IDbContextFactory<Data.AppDbContext> DbFactory { get; set; } = default!;
        [Inject] private NavigationManager Nav { get; set; } = default!;

        private List<User> users = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                using var context = await DbFactory.CreateDbContextAsync();
                // Csak azokat kérjük le, ahol az alapvető adatok megvannak, 
                // hogy elkerüljük a null hibát a listázásnál
                users = await context.Users.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba az adatok betöltésekor: {ex.Message}");
                users = new List<User>(); // Üres lista, hogy ne omoljon össze az UI
            }
        }

        private string GetRoleName(int roleId) => roleId switch
        {
            1 => "Diák",
            2 => "Osztályfőnök",
            5 => "Igazgató",
            9 => "Admin",
            _ => "Egyéb"
        };

        private string GetBadgeClass(int roleId) => roleId switch
        {
            1 => "bg-info-light text-info",
            2 => "bg-warning-light text-warning",
            5 => "bg-danger-light text-danger",
            9 => "bg-primary-light text-primary",
            _ => "bg-secondary-light text-secondary"
        };
    }
}