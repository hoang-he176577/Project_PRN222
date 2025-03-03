namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("exam")]
public class Exam
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public  Subject Subject { get; set; }
    public int ClassId { get; set; }
    public  Class Class { get; set; }
    public DateTime ExamDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int RoomId { get; set; }
    public  Room Room { get; set; }
    public int TeacherId { get; set; }
    public  User Teacher { get; set; }

    public int TermId { get; set; } 
    public  Term Term { get; set; }
}