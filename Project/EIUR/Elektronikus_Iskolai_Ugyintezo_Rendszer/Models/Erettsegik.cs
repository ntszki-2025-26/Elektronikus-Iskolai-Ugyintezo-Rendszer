namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("Erettsegi")]
    public class Erettsegik
    {
        [Key]
        public required Guid Id { get; set; }
        [Required]
        public required Guid UserId { get; set; }
        [Required]
        public required int SubjectId { get; set; }
        [Required]
        public required bool Lvl { get; set; }
    }
}
