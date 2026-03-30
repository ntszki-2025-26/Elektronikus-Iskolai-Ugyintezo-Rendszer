using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Microsoft.EntityFrameworkCore;
using DbTask = Elektronikus_Iskolai_Ugyintezo_Rendszer.Models.Taskses;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public class RequestService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public RequestService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<DbTask>> GetRequestsAsync()
        {
            using var context = _dbFactory.CreateDbContext();

            return await context.Taskses.ToListAsync();
        }

        public async Task AddRequestAsync(DbTask task)
        {
            using var context = _dbFactory.CreateDbContext();
            context.Taskses.Add(task);
            await context.SaveChangesAsync();
        }
    }
}