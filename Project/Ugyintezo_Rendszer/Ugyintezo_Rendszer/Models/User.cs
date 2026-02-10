namespace Ugyintezo_Rendszer.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid  Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        // Foreign key to Role
        public int RoleId { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        [Required]
        [Base64String]
        public required string Password { get; set; }

    }
}
