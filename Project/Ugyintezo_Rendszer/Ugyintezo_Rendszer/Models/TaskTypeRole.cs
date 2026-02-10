namespace Ugyintezo_Rendszer.Models
{
    [Table("TaskTypeRoles")]
    public class TaskTypeRole
    {
        [Key]
        public int Id { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int TaskTypeId { get; set; }
        //nem tudom hogy kell ide foreign key-t csinálni
        [Required]
        public required int RoleId { get; set; }

    }
}
