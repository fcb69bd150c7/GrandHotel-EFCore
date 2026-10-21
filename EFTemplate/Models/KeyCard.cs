using System;

namespace EFTemplate.Models;

public class KeyCard
{
    public int Id { get; set; }
    public string CardCode { get; set; } = string.Empty;
    public DateTime IssuedAt { get; set; } = DateTime.Now;

    public int RoomId { get; set; }
    public Room? Room { get; set; }
}

