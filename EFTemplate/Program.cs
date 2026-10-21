using EFTemplate.Data;
using EFTemplate.Demos;
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "GrandHotel: Введение в Entity Framework Core";

Console.WriteLine("Гостиничный комплекс 'GrandHotel' (Entity Framework Core)\n");

using (var db = new AppDbContext())
{
    DbInitializer.ResetAndSeed(db);

    CrudOperations.Run(db);
    ChangeTracker.Run(db);
    RelationshipsDemo.Run(db);
}

if (!Console.IsInputRedirected)
{
    Console.WriteLine("\nНажмите любую клавишу для завершения...");
    Console.ReadKey();
}
