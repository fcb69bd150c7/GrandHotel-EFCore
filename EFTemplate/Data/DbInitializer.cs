using EFTemplate.Models;
using System;
using System.Collections.Generic;

namespace EFTemplate.Data;

public static class DbInitializer
{
    public static void ResetAndSeed(AppDbContext context)
    {
        Console.WriteLine("\n[БАЗА ДАННЫХ] Удаление старой версии SQLite...");
        context.Database.EnsureDeleted();

        Console.WriteLine("[БАЗА ДАННЫХ] Создание структуры по текущим моделям...");
        context.Database.EnsureCreated();

        var standard = new RoomCategory { Name = "Стандарт", BasePrice = 2800m };
        var suite = new RoomCategory { Name = "Люкс", BasePrice = 7500m };

        var room101 = new Room
        {
            RoomNumber = "101",
            Floor = 1,
            RoomCategory = standard,
            KeyCard = new KeyCard { CardCode = "KEY-101" }
        };

        var room102 = new Room
        {
            RoomNumber = "102",
            Floor = 1,
            RoomCategory = standard,
            KeyCard = new KeyCard { CardCode = "KEY-102" }
        };

        var room201 = new Room
        {
            RoomNumber = "201",
            Floor = 2,
            RoomCategory = suite,
            KeyCard = new KeyCard { CardCode = "KEY-201" }
        };

        context.RoomCategories.AddRange(standard, suite);
        context.Rooms.AddRange(room101, room102, room201);

        context.SaveChanges();

        Console.WriteLine("[БАЗА ДАННЫХ] База успешно пересоздана и наполнена!\n");
    }
}
