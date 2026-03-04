namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    [Table("TaskTypeRoles")]
    public class TaskTypeRole
    {
        [Key]
        public required int Id { get; set; }
        [Required]
        public required int TaskTypeId { get; set; }
        [Required]
        public required int RoleId { get; set; }
    }
}
