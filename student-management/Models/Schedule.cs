namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("schedule")]
public class Schedule
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public  Class Class { get; set; }

    public int TermId { get; set; } 
    public Term Term { get; set; }  
    public int RoomId { get; set; }
    public  Room Room { get; set; }
    public int SubjectId { get; set; }
    public  Subject Subject { get; set; }
    public int TeacherId { get; set; }
    public  User Teacher { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string DaysOfWeek { get; set; } = ""; // Lưu dạng "Monday,Wednesday"

    // Các ca học (1: Sáng, 2: Chiều, 3: Tối)
    public string StudySessions { get; set; } = ""; // Lưu dạng "1,2,3"

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}