namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Vezetéknév kötelező")]
        public string FirstName { get; set; } = "";

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Keresztnév kötelező")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Email kötelező"), EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Válassz szerepkört")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Telefonszám kötelező")]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "Jelszó kötelező"), MinLength(6)]
        public string Password { get; set; } = "";
    }
}
