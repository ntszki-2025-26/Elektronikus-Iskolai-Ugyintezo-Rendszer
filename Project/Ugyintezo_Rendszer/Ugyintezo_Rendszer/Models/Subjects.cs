namespace Ugyintezo_Rendszer.Models
{
    [Table("Subject")]
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
