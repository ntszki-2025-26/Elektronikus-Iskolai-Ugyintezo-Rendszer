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
        Task<bool> HianyzasHandle(DateTime mettol, DateTime meddig, string message);
        Task<bool> LakcimValtoztatas(int iranyitoszam, string telepules, string utca, int hazszam, string? egyeb);
        Task<bool> ErettsegiJelentkezes(string tantargy, string szint);

    }

    public class TaskService : ITaskService
    {

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

            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;


            var ujIgenyles = new Taskses
            {
                Title = "Iskolalátogatási igazolás",
                TaskTypeId = 1,
                ReportDate = DateTime.Now,
                Message = $"Választott nyelv: {nyelv}",

                SenderUserId = Guid.Parse(userIdStr),
                State = 0
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

                SenderUserId = Guid.Parse(userIdStr),
                State = 0
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
                SenderUserId = Guid.Parse(userIdStr),
                State = 0
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
                SenderUserId = Guid.Parse(userIdStr),
                State = 0
            };

            _context.Taskses.Add(ujIgenyles);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> HianyzasHandle(DateTime mettol, DateTime meddig, string message)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;


            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;


            var ujHianyzas = new Hianyzasok
            {
                UserId = Guid.Parse(userIdStr),
                DateFrom = mettol,
                DateTo = meddig,
                Message = message
            };

            _context.Hianyzas.Add(ujHianyzas);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> LakcimValtoztatas(int iranyitoszam, string telepules, string utca, int hazszam, string? egyeb)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;


            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            var egyebText = string.IsNullOrEmpty(egyeb) ? "Nincs" : egyeb;


            var ujLakcim = new Taskses
            {
                Title = "Lakcímváltoztatás kérelem",
                TaskTypeId = 5,
                ReportDate = DateTime.Now,
                SenderUserId = Guid.Parse(userIdStr),
                Message = $"Lakcímet szeretnék változatni. Irányítószám: {iranyitoszam}, Település: {telepules}, " +
                $"utca/közterület: {utca}, házszám: {hazszam}, egyéb: {egyebText}",
                State = 0
            };

            _context.Taskses.Add(ujLakcim);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ErettsegiJelentkezes(string tantargy, string szint)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;


            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr)) return false;

            var ujJelentkezes = new Taskses
            {
                Title = "Érettségi jelentkezés",
                TaskTypeId = 8,
                ReportDate = DateTime.Now,
                Message = $"Tantárgy: {tantargy}, Szint: {szint}",

                SenderUserId = Guid.Parse(userIdStr),
                State = 0
            };

            _context.Taskses.Add(ujJelentkezes);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}