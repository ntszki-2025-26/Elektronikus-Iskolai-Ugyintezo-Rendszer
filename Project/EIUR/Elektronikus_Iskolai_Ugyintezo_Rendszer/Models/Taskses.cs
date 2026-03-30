namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("Tasks")]
    public class Taskses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required int TaskTypeId { get; set; }
        [Required]
        public required DateTime ReportDate { get; set; } = DateTime.Now;
        public string? Message { get; set; }
        [Required]
        public required Guid SenderUserId { get; set; }
        public int State { get; set; }
    }
}
