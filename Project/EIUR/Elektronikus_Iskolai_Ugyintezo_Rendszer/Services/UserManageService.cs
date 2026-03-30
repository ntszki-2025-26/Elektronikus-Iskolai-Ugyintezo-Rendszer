using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
   
    
    public interface IUserManagementService
    {
        Task DisableUser(Guid id);
        Task UpdateUser(Guid id, User user);
    }

    public class UserManagementService : IUserManagementService
    {
        public UserManagementService(AppDbContext context)
        {
            this.context = context;
        }
        private readonly AppDbContext context;
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
    }
    
}
