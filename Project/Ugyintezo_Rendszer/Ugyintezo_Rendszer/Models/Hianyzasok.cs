namespace Ugyintezo_Rendszer.Models
{
    [Table("Hianyzas")]
    public class Hianyzasok
    {
        [Key]
        public int Id { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required Guid UserId { get; set; }
        [Required]
        public required DateTime DateFrom { get; set; } = DateTime.Now;
        [Required]
        public required DateTime DateTo { get; set; } = DateTime.Now;
        [Required]
        public required string Message { get; set; }

    }
}
