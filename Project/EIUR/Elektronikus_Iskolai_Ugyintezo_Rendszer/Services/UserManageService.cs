using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System.Security.Claims;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{


    public interface IUserManagementService
    {
        Task DisableUser(Guid id);
        Task UpdateUser(Guid id, User user);
        Task<string> GetCurrentUserNameAsync();
        Task StateChange(int taskId, int ujAllapot);
        Task<(User? user, StudentDatas? studentData)> GetCurrentUserDataAsync();
    }

    public class UserManagementService : IUserManagementService
    {
        public UserManagementService(AppDbContext context, AuthenticationStateProvider authStateProvider)
        {
            this.context = context;
            this.authStateProvider = authStateProvider;
        }
        private readonly AppDbContext context;
        private readonly AuthenticationStateProvider authStateProvider;
        public async Task DisableUser(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsEnabled = false;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nincs ilyen user!");
            }
        }

        public async Task UpdateUser(Guid id, User user)
        {
            User u = await context.Users.FindAsync(id);
            u.Id = user.Id;
            u.IsEnabled = user.IsEnabled;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.MiddleName = user.MiddleName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            u.Password = user.Password;
            u.RoleId = user.RoleId;

            await context.SaveChangesAsync();

        }

        public async Task<string> GetCurrentUserNameAsync()
        {
            var authState = await authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out Guid userId))
            {
                return "Vendég";
            }

            var dbUser = await context.Users.FindAsync(userId);

            if (dbUser == null) return "Ismeretlen Felhasználó";
            string middle = string.IsNullOrWhiteSpace(dbUser.MiddleName) ? "" : $" {dbUser.MiddleName}";

            return $"{dbUser.LastName} {middle} {dbUser.FirstName}";
        }

        public async Task StateChange(int taskId, int ujAllapot)
        {

            var task = await context.Taskses.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task != null)
            {
                // Itt a 'Status' az adatbázisoszlop neve a modelledben
                task.State = ujAllapot;

                // Elmentjük a változásokat az adatbázisba
                await context.SaveChangesAsync();
            }
        }

        public async Task<(User? user, StudentDatas? studentData)> GetCurrentUserDataAsync()
        {
            var authState = await authStateProvider.GetAuthenticationStateAsync();
            var userIdStr = authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out Guid userId))
                return (null, null);

            var dbUser = await context.Users.FindAsync(userId);
            var studentData = await context.StudentData.FirstOrDefaultAsync(s => s.UserId == userId);

            return (dbUser, studentData);
        }
    }

}
