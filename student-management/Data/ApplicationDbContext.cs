using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Term> Terms { get; set; }

    private static readonly DateTime StartDate = new DateTime(2024, 1, 1);
    private static readonly DateTime EndDate = new DateTime(2024, 6, 1);
    private static readonly DateTime ExamDate = new DateTime(2024, 5, 15);
    private static readonly TimeSpan ScheduleStartTime = new TimeSpan(8, 0, 0);
    private static readonly TimeSpan ScheduleEndTime = new TimeSpan(10, 0, 0);
    private static readonly TimeSpan ExamStartTime = new TimeSpan(9, 0, 0);
    private static readonly TimeSpan ExamEndTime = new TimeSpan(11, 0, 0);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w => w.Log((RelationalEventId.PendingModelChangesWarning, LogLevel.Warning)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithOne(u => u.Class)
            .HasForeignKey(u => u.ClassId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Schedules)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Room)
            .WithMany()
            .HasForeignKey(s => s.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Subject)
            .WithMany()
            .HasForeignKey(s => s.SubjectId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Teacher)
            .WithMany()
            .HasForeignKey(s => s.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Subject)
            .WithMany()
            .HasForeignKey(e => e.SubjectId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Class)
            .WithMany()
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Room)
            .WithMany()
            .HasForeignKey(e => e.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

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

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany()
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Schedule)
            .WithMany()
            .HasForeignKey(a => a.ScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDeleted);

        modelBuilder.Entity<Score>()
            .HasOne(s => s.Term)
            .WithMany()
            .HasForeignKey(s => s.TermId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Term>().HasData(
            new Term { Id = 1, TermName = "Học kỳ 1 - 2024" },
            new Term { Id = 2, TermName = "Học kỳ 2 - 2024" },
            new Term { Id = 3, TermName = "Học kỳ 1 - 2025" }
        );

        for (int i = 1; i <= 20; i++)
        {
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = i, SubjectName = $"Môn học {i}" });
        }

        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<Room>().HasData(new Room { Id = i, RoomName = $"Phòng {i}A", Capacity = 30 + (i * 2) });
        }

        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<Class>().HasData(new Class { Id = i, ClassName = $"Lớp CNTT-{i}", TeacherId = i });
        }

        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = i,
                Name = $"Giáo viên {i}",
                Username = $"teacher{i}",
                PasswordHash = $"teacher{i}123",
                Email = $"teacher{i}@example.com",
                PhoneNumber = $"09876543{i}",
                Role = UserRole.Teacher
            });
        }

        for (int i = 11; i <= 110; i++)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = i,
                Name = $"Sinh viên {i}",
                Username = $"student{i}",
                PasswordHash = $"student{i}123",
                Email = $"student{i}@example.com",
                PhoneNumber = $"09012345{i}",
                Role = UserRole.Student,
                ClassId = (i - 10) % 10 + 1
            });
        }

        for (int i = 1; i <= 50; i++)
        {
            modelBuilder.Entity<Schedule>().HasData(new Schedule
            {
                Id = i,
                ClassId = (i % 10) + 1,
                RoomId = (i % 10) + 1,
                SubjectId = (i % 20) + 1,
                TeacherId = (i % 10) + 1,
                StartDate = StartDate,
                EndDate = EndDate,
                DaysOfWeek = "Monday,Wednesday",
                StudySessions = "1",
                TermId = (i % 3) + 1
            });
        }

        for (int i = 1; i <= 20; i++)
        {
            modelBuilder.Entity<Exam>().HasData(new Exam
            {
                Id = i,
                SubjectId = (i % 20) + 1,
                ClassId = (i % 10) + 1,
                ExamDate = ExamDate,
                StartTime = ExamStartTime,
                EndTime = ExamEndTime,
                RoomId = (i % 10) + 1,
                TeacherId = (i % 10) + 1,
                TermId = (i % 3) + 1
            });
        }

        int attendanceId = 1;
        for (int i = 11; i <= 110; i++)
        {
            for (int j = 1; j <= 2; j++)
            {
                modelBuilder.Entity<Attendance>().HasData(new Attendance
                {
                    Id = attendanceId++,
                    StudentId = i,
                    ScheduleId = (j % 50) + 1,
                    Status = (AttendanceStatus)(j % 3),
                    Date = StartDate
                });
            }
        }

        int scoreId = 1;
        for (int i = 11; i <= 110; i++)
        {
            for (int j = 1; j <= 1; j++)
            {
                modelBuilder.Entity<Score>().HasData(new Score
                {
                    Id = scoreId++,
                    StudentId = i,
                    SubjectId = (j % 20) + 1,
                    Value = 8.5m,
                    Date = StartDate,
                    TermId = (j % 3) + 1
                });
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}