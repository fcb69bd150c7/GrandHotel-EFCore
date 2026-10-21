using EFTemplate.Data;
using EFTemplate.Models;
using System;

namespace EFTemplate.Demos;

public static class ChangeTracker
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n--- 2. CHANGE TRACKER (ТРЕКЕР СОСТОЯНИЙ) ---");

        var room = new Room { RoomNumber = "Тест-100", Floor = 1, RoomCategoryId = 1 };
        Console.WriteLine($"1. Новый объект в памяти: State = {db.Entry(room).State}");

        db.Rooms.Add(room);
        Console.WriteLine($"2. После db.Rooms.Add(): State = {db.Entry(room).State}");

        db.SaveChanges();
        Console.WriteLine($"3. После db.SaveChanges(): State = {db.Entry(room).State}");

        room.RoomNumber = "Тест-105";
        Console.WriteLine($"4. Изменили свойство в коде: State = {db.Entry(room).State}");

        db.Rooms.Remove(room);
        Console.WriteLine($"5. После db.Rooms.Remove(): State = {db.Entry(room).State}");

        db.SaveChanges();
        Console.WriteLine($"6. После удаления и SaveChanges(): State = {db.Entry(room).State}");
    }
}
