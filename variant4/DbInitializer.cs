using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using variant4.Models;

public static class DbInitializer
{
    public static void Initialize(Variant4Context context)
    {
        try
        {
            // Создаем базу данных, если ее нет
            context.Database.EnsureCreated();

            // Создаем роли, если их нет
            if (!context.Roles.Any())
            {
                var roles = new Role[]
                {
                    new Role { Id = 1, Name = "Admin", AccessRights = "Full" }, // Явно указываем Id = 1 для админа
                    new Role { Id = 2, Name = "User", AccessRights = "Limited" }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
                Console.WriteLine("Роли успешно созданы");
            }

            // Проверяем существование администратора (по RoleId = 1)
            bool adminExists = context.Users.Any(u => u.RoleId == 1);

            // Дополнительная проверка на уникальность логина
            bool adminLoginExists = context.Users.Any(u => u.Login == "admin");

            if (!adminExists && !adminLoginExists)
            {
                var admin = new User
                {
                    Login = "admin",
                    Password = "admin123",
                    Name = "Admin",
                    Surname = "Admin",
                    Phone = "+1234567890",
                    RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                    RoleId = 1 // Явно указываем RoleId = 1
                };

                context.Users.Add(admin);
                context.SaveChanges();
                Console.WriteLine("Аккаунт администратора успешно создан");
            }
            else if (adminLoginExists)
            {
                Console.WriteLine("Пользователь с логином 'admin' уже существует");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка инициализации БД: {ex.Message}");
            throw;
        }
    }
}