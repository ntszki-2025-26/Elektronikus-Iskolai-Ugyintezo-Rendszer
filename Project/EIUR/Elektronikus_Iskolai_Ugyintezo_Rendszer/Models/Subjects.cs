namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("Subject")]
    public class Subjects
    {
        [Key]
        public required int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
