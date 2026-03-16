using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;



namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Components.Pages
{
    public partial class LogIn
    {

        [SupplyParameterFromForm]
        public LoginModel loginModel { get; set; } = new LoginModel();

        string? errorMessage;

        async Task LoginUser()
        {
            errorMessage = null;

            using var db = await DbFactory.CreateDbContextAsync();

            var user = await db.Users
                .FirstOrDefaultAsync(u => u.Email == loginModel.Email);

            // Csak egyszer vizsgáljuk a jelszót!
            if (user != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                // A korábbi egyetlen NavigateTo helyett ide jön a logikád
                switch (user.RoleId)
                {
                    case 1:
                        Nav.NavigateTo("/DiakHome");
                        break;
                    case 2:
                        Nav.NavigateTo("/OfoHome");
                        break;
                    case 3:
                        Nav.NavigateTo("/IgazgatoHelyettesHome");
                        break;
                    case 4:
                        Nav.NavigateTo("/SzakképzésvezetoHome");
                        break;
                    case 5:
                        Nav.NavigateTo("/IgazgatoHome");
                        break;
                    case 6:
                        Nav.NavigateTo("/GazdaságiTitkárHome");
                        break;
                    case 7:
                        Nav.NavigateTo("/TitkárHome");
                        break;
                    case 8:
                        Nav.NavigateTo("/KonyvtarosHome");
                        break;
                    case 9:
                        Nav.NavigateTo("/Admin");
                        break;
                    default:
                        Nav.NavigateTo("/Home");
                        break;
                }
            }
            else
            {
                errorMessage = "Hibás email cím vagy jelszó!";
            }
        }

        public class LoginModel
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
        }

        private bool isPasswordVisible = false;

        // Ezt a metódust fogjuk hívni a szem ikonra kattintva
        private void TogglePasswordVisibility()
        {
            isPasswordVisible = !isPasswordVisible;
        }

        // Segédváltozó a HTML attribútumhoz
        private string PasswordInputType => isPasswordVisible ? "text" : "password";
        private string PasswordIcon => isPasswordVisible ? "bi-eye-slash" : "bi-eye";
    }
}

