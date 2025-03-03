namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("room")]
public class Room
{
    public int Id { get; set; }
    public required string RoomName { get; set; }
    public int Capacity { get; set; }
}