using System.ComponentModel.DataAnnotations.Schema;

[Table("term")]
public class Term
{
    public int Id { get; set; }
    public required string TermName { get; set; } // Ví dụ: "Học kỳ 1 - 2025"
}
