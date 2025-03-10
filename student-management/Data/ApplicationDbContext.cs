using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace StudentManagement.Data
{
    public enum AttendanceStatus { Present, Absent, Late }
    public enum UserRole { Admin, Teacher, Student }

    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    [Table("classes")]
    public class Class
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User? Teacher { get; set; }
        public List<ClassMember> Members { get; set; } = new();
    }

    [Table("class_members")]
    public class ClassMember
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }

    [Table("subjects")]
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    [Table("terms")]
    public class Term
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    [Table("rooms")]
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
    }

    [Table("schedules")]
    public class Schedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User Teacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DaysOfWeek { get; set; }
        public string StudySessions { get; set; }
    }

    [Table("exams")]
    public class Exam
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        public DateTime ExamDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User Teacher { get; set; }
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
    }
    [Table("attendances")]
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }

        public AttendanceStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
    [Table("notifications")]
    public class Notification
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User? Sender { get; set; }
        public int? ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User? Receiver { get; set; }
        public required string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    [Table("scores")]
    public class Score
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User Student { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }
        public decimal Value { get; set; }
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassMember> ClassMembers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Score> Scores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w => w.Log((RelationalEventId.PendingModelChangesWarning, LogLevel.Warning)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassMember>().HasKey(cm => new { cm.Id });

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Members)
                .WithOne(cm => cm.Class)
                .HasForeignKey(cm => cm.ClassId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Subject)
                .WithMany()
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Exam)
                .WithMany()
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Term)
                .WithMany()
                .HasForeignKey(s => s.TermId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany()
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}