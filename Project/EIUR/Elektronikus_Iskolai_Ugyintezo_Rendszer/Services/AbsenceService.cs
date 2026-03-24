using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.EntityFrameworkCore;


namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;

public class AbsenceService
{
    private readonly AppDbContext _context;
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public AbsenceService(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateAbsenceWithNotification(Hianyzasok absence, int taskTypeId, Guid currentUserId)
    {
        // A hiányzáshoz rendeljük a bejelentkezett felhasználót
        absence.UserId = currentUserId;

        // SQL Datetime korrekció (1753 előtti dátumok kezelése)
        if (absence.DateFrom < new DateTime(1753, 1, 1)) absence.DateFrom = DateTime.Now;
        if (absence.DateTo < new DateTime(1753, 1, 1)) absence.DateTo = DateTime.Now;

        _context.Hianyzas.Add(absence);
        await _context.SaveChangesAsync();

        // Értesítés létrehozása
        var task = new Taskses
        {
            Id = 0, // Kötelező kezdőérték
            Title = "Hiányzás bejelentés",
            TaskTypeId = taskTypeId,
            SenderUserId = currentUserId, // Guid típus
            ReportDate = DateTime.Now,
            Message = $"Időszak: {absence.DateFrom:yyyy.MM.dd} - {absence.DateTo:yyyy.MM.dd}. Indok: {absence.Message}"
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task<List<NotificationDto>> GetNotificationsByRole(int userRoleId)
    {
        // 1. Létrehozunk egy saját contextet csak ehhez a lekérdezéshez
        using var _context = await _contextFactory.CreateDbContextAsync();

        // 2. Lefuttatjuk a lekérdezést (a kódod többi része marad változatlan)
        var notifications = await (from task in _context.Tasks
                                   join user in _context.Users on task.SenderUserId equals user.Id
                                   select new NotificationDto
                                   {
                                       TaskId = task.Id,
                                       // Magyar név összefűzése
                                       SenderName = user.LastName + " " +
                                                   (user.MiddleName != null ? user.MiddleName + " " : "") +
                                                   user.FirstName,
                                       ReportDate = task.ReportDate,
                                       Message = task.Message ?? ""
                                   }).ToListAsync();

        return notifications;
    }
}