using System.ComponentModel.DataAnnotations;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Az email cím megadása kötelező.")]
        [EmailAddress(ErrorMessage = "Nem megfelelő email formátum.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A jelszó megadása kötelező.")]
        public string Password { get; set; } = string.Empty;
    }
}