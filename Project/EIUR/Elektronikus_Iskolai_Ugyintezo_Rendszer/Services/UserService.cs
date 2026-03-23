using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public class UserService
    {
        AppDbContext db;
        public async Task Deactivate(Guid Id)
        {
            User user = db.Users.Single(a => a.Id == Id);
            user.IsEnabled = 1;
            await db.SaveChangesAsync();
            
    }
        public Guid? CurrentUserId { get; set; }
        public int CurrentRoleId { get; set; }
        public string? CurrentUserName { get; set; }

    }
}
