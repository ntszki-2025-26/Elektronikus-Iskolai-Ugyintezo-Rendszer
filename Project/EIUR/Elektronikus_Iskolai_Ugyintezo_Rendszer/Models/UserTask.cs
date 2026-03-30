using System;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models
{
    public class UserTask
    {
        public string StudentName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsDone { get; set; } = false;
    }
}