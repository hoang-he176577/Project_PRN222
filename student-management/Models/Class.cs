namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
[Table("class")]
public class Class
{
   public int Id { get; set; }
    public required string ClassName { get; set; }
    public List<User> Students { get; set; } = new List<User>(); 
    public List<Schedule> Schedules { get; set; } = new List<Schedule>(); 

    public int? TeacherId { get; set; }
    public User? Teacher { get; set; }
}