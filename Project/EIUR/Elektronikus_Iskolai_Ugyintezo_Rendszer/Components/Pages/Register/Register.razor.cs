using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages.Register
{
    public partial class Register
    {
        [Inject] private IDbContextFactory<Data.AppDbContext> DbFactory { get; set; } = default!;
        [Inject] private NavigationManager NavManager { get; set; } = default!;

        [SupplyParameterFromForm]
        private User registrationUser { get; set; } = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "",
            LastName = "",
            Email = "",
            PhoneNumber = "",
            Password = "",
            RoleId = 0,
            IsEnabled = 1
        };

        private string? errorMessage;
        private bool isPasswordVisible = false;

        private string PasswordInputType => isPasswordVisible ? "text" : "password";
        private string PasswordIcon => isPasswordVisible ? "bi-eye-slash" : "bi-eye";

        private void TogglePasswordVisibility() => isPasswordVisible = !isPasswordVisible;

        private async Task HandleRegistration()
        {
            try
            {
                errorMessage = null;

                using var context = await DbFactory.CreateDbContextAsync();

                var existingUser = await context.Users.AnyAsync(u => u.Email == registrationUser.Email);
                if (existingUser)
                {
                    errorMessage = "Ez az email cím már használatban van!";
                    return;
                }


                registrationUser.Password = BCrypt.Net.BCrypt.HashPassword(registrationUser.Password);

                if (registrationUser.Id == Guid.Empty)
                    registrationUser.Id = Guid.NewGuid();

                context.Users.Add(registrationUser);
                int rowsAffected = await context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    NavManager.NavigateTo("/admin");
                }
                else
                {
                    errorMessage = "A rendszer nem mentett el új adatot. Ellenőrizd a kapcsolatot!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Hiba: {ex.GetBaseException().Message}";
            }
        }
    }
}