using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.EntityFrameworkCore;


namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services;

public class AbsenceService
{

    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public AbsenceService(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Hianyzasok>> GetAbsencesByUserId(Guid userId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Hianyzas.Where(h => h.UserId == userId).ToListAsync();
    }


    public async Task CreateAbsenceWithNotification(Hianyzasok absence, int taskTypeId, Guid currentUserId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        absence.UserId = currentUserId;


        if (absence.DateFrom < new DateTime(1753, 1, 1)) absence.DateFrom = DateTime.Now;
        if (absence.DateTo < new DateTime(1753, 1, 1)) absence.DateTo = DateTime.Now;

        context.Hianyzas.Add(absence);
        await context.SaveChangesAsync();


        var task = new Taskses
        {
            Id = 0, 
            Title = "Hiányzás bejelentés",
            TaskTypeId = taskTypeId,
            SenderUserId = currentUserId, 
            ReportDate = DateTime.Now,
            Message = $"Időszak: {absence.DateFrom:yyyy.MM.dd} - {absence.DateTo:yyyy.MM.dd}. Indok: {absence.Message}"
        };

        context.Taskses.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task<List<NotificationDto>> GetNotificationsByRole(int userRoleId)
    {

        using var _context = await _contextFactory.CreateDbContextAsync();


        var notifications = await (from task in _context.Taskses
                                   join user in _context.Users on task.SenderUserId equals user.Id
                                   select new NotificationDto
                                   {
                                       TaskId = task.Id,

                                       SenderName = user.LastName + " " +
                                                   (user.MiddleName != null ? user.MiddleName + " " : "") +
                                                   user.FirstName,
                                       ReportDate = task.ReportDate,
                                       Message = task.Message ?? ""
                                   }).ToListAsync();

        return notifications;
    }
}