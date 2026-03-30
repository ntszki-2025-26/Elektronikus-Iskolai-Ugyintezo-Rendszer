using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.EntityFrameworkCore;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<Replie> Replies { get; set; }
        public DbSet<Hianyzasok> Hianyzas { get; set; }
        public DbSet<Erettsegik> Erettsegi { get; set; }
        public DbSet<StudentDatas> StudentData { get; set; }
        public DbSet<TaskTypeRole> TaskTypeRoles { get; set; }
        public DbSet<TaskTypes> TaskType { get; set; }
        public DbSet<Taskses> Taskses { get; set; }
    }
}