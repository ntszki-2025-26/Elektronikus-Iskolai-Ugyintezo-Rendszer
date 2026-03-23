namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
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
        public required int ZIP { get; set; }
        [Required]
        public required int OM_Number { get; set; }
        [Required]
        public required Guid UserId { get; set; }
    }
}
