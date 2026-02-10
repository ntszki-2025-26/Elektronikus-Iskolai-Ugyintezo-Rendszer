namespace Ugyintezo_Rendszer.Models
{
    [Table("Erettsegi")]
    public class Erettsegik
    {
        [Key]
        public Guid Id { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required Guid UserId { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int SubjectId { get; set; }
        [Required]
        public required bool Lvl { get; set; }
    }
}
