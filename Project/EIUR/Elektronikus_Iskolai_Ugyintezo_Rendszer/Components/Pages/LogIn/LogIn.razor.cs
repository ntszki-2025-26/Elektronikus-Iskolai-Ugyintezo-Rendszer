using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages.LogIn
{
    public partial class LogIn
    {
        [Inject] public NavigationManager Nav { get; set; } = default!;
        [Inject] public IDbContextFactory<AppDbContext> DbFactory { get; set; } = default!;
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

        [SupplyParameterFromForm]
        public LoginModel loginModel { get; set; } = new LoginModel();

        public string? errorMessage;


        public bool isPasswordVisible = false;
        public string PasswordInputType => isPasswordVisible ? "text" : "password";
        public string PasswordIcon => isPasswordVisible ? "bi-eye-slash" : "bi-eye";

        public void TogglePasswordVisibility()
        {
            isPasswordVisible = !isPasswordVisible;
        }

        public async Task LoginUser()
        {
            errorMessage = null;
            using var db = await DbFactory.CreateDbContextAsync();
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                ((CustomAuthenticationStateProvider)AuthStateProvider)
                    .MarkUserAsAuthenticated(user.FirstName, user.Id.ToString(), user.RoleId.ToString());

                switch (user.RoleId)
                {
                    case 1: Nav.NavigateTo("/DiakHome"); break;
                    case 2: Nav.NavigateTo("/OfoHome"); break;
                    case 3: Nav.NavigateTo("/IgazgatoHelyettesHome"); break;
                    case 4: Nav.NavigateTo("/SzakkepzesvezetoHome"); break;
                    case 5: Nav.NavigateTo("/IgazgatoHome"); break;
                    case 6: Nav.NavigateTo("/GazdasagiTitkarHome"); break;
                    case 7: Nav.NavigateTo("/TitkarHome"); break;
                    case 8: Nav.NavigateTo("/KonyvtarosHome"); break;
                    case 9: Nav.NavigateTo("/Admin"); break;
                    default: Nav.NavigateTo("/"); break;
                }
            }
            else
            {
                errorMessage = "Hibás email cím vagy jelszó!";
            }
        }
    }

    public class LoginModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}