using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;   // <--- Ellenőrizd, hogy ez a pontos névtér!
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models; // <--- Itt vannak a Taskses.cs-ben lévő osztályok
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task<bool> CreateIskolaLatogatasiRequest(string nyelv);
    }

    public class TaskService : ITaskService
    {
        // A hibaüzenet szerint nálad AppDbContext a neve, nem ApplicationDbContext
        private readonly AppDbContext _context;
        private readonly AuthenticationStateProvider _authStateProvider;

        public TaskService(AppDbContext context, AuthenticationStateProvider authStateProvider)
        {
            _context = context;
            _authStateProvider = authStateProvider;
        }

        public async System.Threading.Tasks.Task<bool> CreateIskolaLatogatasiRequest(string nyelv)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            // A bejelentkezett user ID-ja stringként jön le
            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            // Példányosítjuk a modellt
            var ujIgenyles = new Taskses
            {
                Title = "Iskolalátogatási igazolás",
                TaskTypeId = 1,
                ReportDate = DateTime.Now,
                Message = $"Választott nyelv: {nyelv}",
                // Itt konvertáljuk a stringet Guid-ra, mert a modelled azt várja:
                SenderUserId = Guid.Parse(userIdStr)
            };

            _context.Tasks.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}