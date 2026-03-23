namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Services
{
    public class UserService
    {
        public Guid? CurrentUserId { get; set; }
        public int CurrentRoleId { get; set; }
        public string? CurrentUserName { get; set; }
    }
}