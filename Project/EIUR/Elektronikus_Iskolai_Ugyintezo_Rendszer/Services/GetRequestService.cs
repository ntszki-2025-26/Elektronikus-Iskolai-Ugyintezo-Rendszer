using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public interface IRequestService
    {
        Task<List<Taskses>> GetDiakTasks(Guid SenderId);

    }

    public class GetRequestService : IRequestService
    {
        private readonly AppDbContext _context;
        private readonly AuthenticationStateProvider _authStateProvider;

        public GetRequestService(AppDbContext context, AuthenticationStateProvider authStateProvider)
        {
            _context = context;
            _authStateProvider = authStateProvider;
        }

        public async Task<List<Taskses>> GetDiakTasks(Guid SenderId)
        {
            return await _context.Taskses.Where(t => t.SenderUserId == SenderId).ToListAsync();
        }


    }
}
