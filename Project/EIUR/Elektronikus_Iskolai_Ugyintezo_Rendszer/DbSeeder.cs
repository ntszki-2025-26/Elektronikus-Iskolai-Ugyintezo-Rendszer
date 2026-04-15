using Elektronikus_Iskolai_Ugyintezo_Rendszer.Data;
using Elektronikus_Iskolai_Ugyintezo_Rendszer.Models;
using Microsoft.EntityFrameworkCore;

namespace Elektronikus_Iskolai_Ugyintezo_Rendszer.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {

            if (!await context.Roles.AnyAsync())
            {
                var roles = new List<Role>
                {
                    new Role { Id = 1, RoleName = "Diák" },
                    new Role { Id = 2, RoleName = "Osztályfőnök" },
                    new Role { Id = 3, RoleName = "Igazgatóhelyettes" },
                    new Role { Id = 5, RoleName = "Igazgató" },
                    new Role { Id = 7, RoleName = "Titkár" },
                    new Role { Id = 9, RoleName = "Admin" },
                };

                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Roles] ON");
                        await context.Roles.AddRangeAsync(roles);
                        await context.SaveChangesAsync();
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Roles] OFF");
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Roles] OFF");
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }


            if (!await context.Subject.AnyAsync())
            {
                var subjects = new List<Subjects>
                {
                    new Subjects { Id = 1,  Name = "Matematika" },
                    new Subjects { Id = 2,  Name = "Történelem" },
                    new Subjects { Id = 3,  Name = "Digitális Kultúra" },
                    new Subjects { Id = 4,  Name = "Magyar Nyelv" },
                    new Subjects { Id = 5,  Name = "Angol" },
                    new Subjects { Id = 6,  Name = "Német" },
                    new Subjects { Id = 7,  Name = "Földrajz" },
                    new Subjects { Id = 8,  Name = "Japán" },
                    new Subjects { Id = 9,  Name = "Testnevelés" },
                    new Subjects { Id = 10, Name = "Fizika" },
                };

                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Subject] ON");
                        await context.Subject.AddRangeAsync(subjects);
                        await context.SaveChangesAsync();
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Subject] OFF");
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Subject] OFF");
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }


            if (!await context.TaskType.AnyAsync())
            {
                var taskTypes = new List<TaskTypes>
                {
                    new TaskTypes { Id = 1, Type = "Iskolalátogatási Igazolás" },
                    new TaskTypes { Id = 2, Type = "Jogviszony igazolás" },
                    new TaskTypes { Id = 3, Type = "MÁK igazolás/árvasági dokumentum" },
                    new TaskTypes { Id = 4, Type = "érettségi vizsga jelentkezés" },
                    new TaskTypes { Id = 5, Type = "lakcím adatok változtatásának bejelentése" },
                    new TaskTypes { Id = 6, Type = "korábbi érettségi vizsgák törzslap másolata" },
                    new TaskTypes { Id = 7, Type = "Hiányzás bejelentés" },
                    new TaskTypes { Id = 8, Type = "érettségi jelentkezés" },
                    new TaskTypes { Id = 9, Type = "panasz bejelentés" },
                };

                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[TaskType] ON");
                        await context.TaskType.AddRangeAsync(taskTypes);
                        await context.SaveChangesAsync();
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[TaskType] OFF");
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[TaskType] OFF");
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }


            if (!await context.Users.AnyAsync(u => u.Email == "admin@gmail.com"))
            {
                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "admin@gmail.com",
                    RoleId = 9,
                    PhoneNumber = "+36301234567",
                    Password = "$2a$12$fG6HPDueYrZv9VZwqlC.VuyFPMuoZWIXps6ALzszVSbMFHM1vygy.",
                    IsEnabled = true,
                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
