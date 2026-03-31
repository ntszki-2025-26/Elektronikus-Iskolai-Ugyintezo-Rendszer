using Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages.Modal;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages.Admin
{
    public partial class Admin
    {
        [Inject] private IDbContextFactory<Data.AppDbContext> DbFactory { get; set; } = default!;
        [Inject] private NavigationManager Nav { get; set; } = default!;
        [Inject] private IDialogService DialogService { get; set; }

        [Inject] private UserManagementService UserManagementService { get; set; } = default!;

        private List<User> users = new();


        private async Task OpenDialog(User user)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };

            var parameters = new DialogParameters<MyModal>
            {
                { x => x.EditedUser, user }
            };

            var dialog = await DialogService.ShowAsync<MyModal>("Admin Szerkesztés", parameters, options);
            var result = await dialog.Result;

            if (!result.Canceled && result.Data is User updatedUser)
            {
                await UserManagementService.UpdateUser(updatedUser.Id, updatedUser);
                int idx = users.FindIndex(u => u.Id == updatedUser.Id);
                if (idx >= 0) users[idx] = updatedUser;
                StateHasChanged();
            }
        }

        private async Task HandleDisable(User user)
        {
            try
            {

                await UserManagementService.DisableUser(user.Id);


                user.IsEnabled = false;

                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a tiltás során: {ex.Message}");
            }
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                using var context = await DbFactory.CreateDbContextAsync();

                users = await context.Users.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba az adatok betöltésekor: {ex.Message}");
                users = new List<User>();
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

        private string GetStatus(bool isEnabled) => isEnabled switch
        {
            false => "Inaktív",
            true => "Aktív"
        };

        private string GetStatusColor(bool isEnabled) => isEnabled switch
        {
            false => "bg-secondary-light text-secondary",
            true => "bg-success-light text-success"
        };
    }
}