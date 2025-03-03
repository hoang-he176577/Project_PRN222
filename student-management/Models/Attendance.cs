using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models;

public enum AttendanceStatus
{
    Present, Absent, Late
}

[Table("attendance")]
public class Attendance
{
    public int Id { get; set; }
    [ForeignKey("StudentId")]
    public int StudentId { get; set; }
    public  User Student { get; set; }
    [ForeignKey("ScheduleId")]
    public int ScheduleId { get; set; }
    public  Schedule Schedule { get; set; }
    public AttendanceStatus Status { get; set; }
    public DateTime Date { get; set; }
}