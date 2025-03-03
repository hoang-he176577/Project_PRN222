using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagement.Models;
[Table("subject")]
public class Subject
{
    public int Id { get; set; }
    public required string SubjectName { get; set; }
}