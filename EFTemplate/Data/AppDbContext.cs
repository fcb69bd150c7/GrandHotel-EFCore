using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EFTemplate.Data;

public class AppDbContext : DbContext
{
    public DbSet<RoomCategory> RoomCategories => Set<RoomCategory>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<KeyCard> KeyCards => Set<KeyCard>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=ef_hotel.db")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomCategory>()
            .HasMany(c => c.Rooms)
            .WithOne(r => r.RoomCategory)
            .HasForeignKey(r => r.RoomCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Room>()
            .HasOne(r => r.KeyCard)
            .WithOne(k => k.Room)
            .HasForeignKey<KeyCard>(k => k.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
