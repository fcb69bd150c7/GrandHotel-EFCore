namespace EFTemplate.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int Floor { get; set; }

    public int RoomCategoryId { get; set; }
    public RoomCategory? RoomCategory { get; set; }

    public KeyCard? KeyCard { get; set; }
}

