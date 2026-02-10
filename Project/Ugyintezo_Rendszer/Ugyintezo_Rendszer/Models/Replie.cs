namespace Ugyintezo_Rendszer.Models
{
    [Table("Replies")]
    public class Replie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required int SenderUserId { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int TaskId { get; set; }
        [Required]
        public required string Content { get; set; }

    }
}
