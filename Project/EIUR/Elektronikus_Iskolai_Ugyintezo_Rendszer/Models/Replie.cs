namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("Replies")]
    public class Replie
    {
        [Key]
        public required int Id { get; set; }
        [Required]
        public required int SenderUserId { get; set; }
        [Required]
        public required int TaskId { get; set; }
        [Required]
        public required string Content { get; set; }
    }
}
