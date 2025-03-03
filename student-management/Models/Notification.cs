namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("notification")]
public class Notification
{
    public int Id { get; set; }
    public int? SenderId { get; set; }
    public required User Sender { get; set; }
    public int? ReceiverId { get; set; }
    public required User Receiver { get; set; }
    public required string Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}