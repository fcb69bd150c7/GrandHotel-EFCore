using EFTemplate.Data;
using EFTemplate.Models;
using System;

namespace EFTemplate.Demos;

public static class CrudOperations
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("--- 1. БАЗОВЫЙ CRUD ---");

        // CREATE
        Console.WriteLine("\n--> [CREATE] Добавляем новый номер...");
        var newRoom = new Room
        {
            RoomNumber = "301",
            Floor = 3,
            RoomCategoryId = 2
        };
        db.Rooms.Add(newRoom);
        db.SaveChanges();
        Console.WriteLine($"Номер добавлен с Id: {newRoom.Id}");

        // READ
        Console.WriteLine("\n--> [READ] Поиск номера по Id...");
        var room = db.Rooms.Find(newRoom.Id);
        Console.WriteLine($"Найден: Номер {room?.RoomNumber}, Этаж: {room?.Floor}");

        // UPDATE
        Console.WriteLine("\n--> [UPDATE] Меняем этаж на 4...");
        if (room != null)
        {
            room.Floor = 4;
            db.SaveChanges();
            Console.WriteLine("Этаж обновлен в базе данных.");
        }

        // DELETE
        Console.WriteLine("\n--> [DELETE] Удаляем номер...");
        if (room != null)
        {
            db.Rooms.Remove(room);
            db.SaveChanges();
            Console.WriteLine("Номер удален из базы данных.");
        }
    }
}
