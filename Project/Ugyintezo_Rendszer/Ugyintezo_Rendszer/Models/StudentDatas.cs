namespace Ugyintezo_Rendszer.Models
{
    [Table("StudentData")]
    public class StudentDatas
    {
        [Key]
        public Guid Id { get; set; }
        public string? Class { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        [Range(1000, 9999)]
        public required int ZIP { get; set; }
        [Required]
        public required int OM_Number { get; set; }
        //továbbra se tudom hogyan kell beállíttani hogy kell összekapcsolni a User táblával
        public Guid UserId { get; set; }
    }
}
