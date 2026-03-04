namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public required Guid Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
