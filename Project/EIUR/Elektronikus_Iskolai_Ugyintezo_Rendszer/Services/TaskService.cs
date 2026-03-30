using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public interface ITaskService
    {
        Task<bool> CreateIskolaLatogatasiRequest(string nyelv);
        Task<bool> CreateJogViszonyIgazolasRequest();
        Task<bool> CreateMakRequest();
        Task<bool> CreateTorzslapRequest();
       
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

        public async Task<bool> CreateIskolaLatogatasiRequest(string nyelv)
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

            _context.Taskses.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateJogViszonyIgazolasRequest()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            var ujIgenyles = new Taskses
            {
                Title = "Jogviszony Igazolás",
                TaskTypeId = 2,
                ReportDate = DateTime.Now,
                Message = "Jogviszony Igazolást szeretnék igényelni.",
                // Itt konvertáljuk a stringet Guid-ra, mert a modelled azt várja:
                SenderUserId = Guid.Parse(userIdStr)
            };

            _context.Taskses.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateMakRequest()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            var ujIgenyles = new Taskses
            {
                Title = "MÁK/Árvasági Igazolás",
                TaskTypeId = 3,
                ReportDate = DateTime.Now,
                Message = "MÁK/Árvasági Igazolást szeretnék igényelni.",
                SenderUserId = Guid.Parse(userIdStr)
            };

            _context.Taskses.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateTorzslapRequest()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            var ujIgenyles = new Taskses
            {
                Title = "Törzslap másolat igénylése",
                TaskTypeId = 6,
                ReportDate = DateTime.Now,
                Message = "Törzslap másolatot szeretnék igényelni.",
                SenderUserId = Guid.Parse(userIdStr)
            };

            _context.Taskses.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}