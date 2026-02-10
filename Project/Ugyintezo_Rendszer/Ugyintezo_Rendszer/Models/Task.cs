namespace Ugyintezo_Rendszer.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int TaskTypeId { get; set; }
        [Required]
        public required DateTime ReportDate { get; set; } = DateTime.Now;
        public string? Message { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int SenderUserId { get; set; }
    }
}
