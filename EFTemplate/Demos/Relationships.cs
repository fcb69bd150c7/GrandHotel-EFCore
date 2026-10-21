using EFTemplate.Data;
using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFTemplate.Demos;

public static class RelationshipsDemo
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n--- 3. СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ ---");

        Console.WriteLine("\n--> Загрузка номеров со связями (Include):");
        var existingRooms = db.Rooms
            .Include(r => r.RoomCategory)
            .Include(r => r.KeyCard)
            .ToList();

        foreach (var r in existingRooms)
        {
            Console.WriteLine($"  - Номер {r.RoomNumber} ({r.RoomCategory?.Name}) | Ключ: {r.KeyCard?.CardCode}");
        }

        // Добавление связанного графа объектов
        var tempCategory = new RoomCategory
        {
            Name = "Тестовая",
            BasePrice = 3000m,
            Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = "999",
                    Floor = 9,
                    KeyCard = new KeyCard { CardCode = "KEY-999" }
                }
            }
        };

        db.RoomCategories.Add(tempCategory);
        db.SaveChanges();
        Console.WriteLine($"Категория '{tempCategory.Name}' добавлена вместе с номером и картой.");

        // Каскадное удаление
        Console.WriteLine("\n--> Удаляем категорию 'Тестовая'...");
        db.RoomCategories.Remove(tempCategory);
        db.SaveChanges();

        // Проверка каскадного удаления
        var orphanRoom = db.Rooms.FirstOrDefault(r => r.RoomNumber == "999");
        Console.WriteLine($"Номер 999 найден в базе? -> {(orphanRoom != null ? "ДА" : "НЕТ (удален каскадно)")}");

        var orphanCard = db.KeyCards.FirstOrDefault(k => k.CardCode == "KEY-999");
        Console.WriteLine($"Ключ-карта KEY-999 найдена в базе? -> {(orphanCard != null ? "ДА" : "НЕТ (удалена каскадно)")}");
    }
}
