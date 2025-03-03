using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagement.Models;
public enum UserRole
{
    Admin, Teacher, Student
}

[Table("user")]

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public UserRole Role { get; set; }

    public int? ClassId { get; set; } // Chỉ sinh viên mới có lớp
    public Class? Class { get; set; }

    public bool IsDeleted { get; set; } = false;
}