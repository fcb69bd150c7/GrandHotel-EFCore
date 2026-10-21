using System.Collections.Generic;

namespace EFTemplate.Models;

public class RoomCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }

    public List<Room> Rooms { get; set; } = new();
}

