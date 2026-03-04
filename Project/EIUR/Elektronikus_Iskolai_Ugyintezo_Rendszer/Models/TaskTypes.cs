namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("TaskType")]
    public class TaskTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Type { get; set; }
    }
}
