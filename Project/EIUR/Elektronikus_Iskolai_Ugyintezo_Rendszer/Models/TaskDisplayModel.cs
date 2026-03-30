namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    public class TaskDisplayModel
    {

        public Taskses BaseTask { get; set; }


        public bool IsDone { get; set; }
        public string StudentName { get; set; } = "Ismeretlen tanuló";
        public string DocumentType { get; set; } = "Általános";
        public string Description => BaseTask.Message; 
    }
}
