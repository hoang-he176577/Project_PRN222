using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models;

[Table("score")]
public class Score
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public  User Student { get; set; }
    public int SubjectId { get; set; }
    public  Subject Subject { get; set; }
    [Range(0, 10)]
    public decimal Value { get; set; }
    public DateTime Date { get; set; }

    public int TermId { get; set; } 
    public  Term Term { get; set; }
}