namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;

public class NotificationDto
{
    public int TaskId { get; set; }
    public string SenderName { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string Message { get; set; } = string.Empty;
}