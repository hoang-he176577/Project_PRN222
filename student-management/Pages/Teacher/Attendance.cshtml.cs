using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

public class AttendanceController : Controller
{
    private readonly ApplicationDbContext _context;

    public AttendanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var classes = _context.Classes.Include(c => c.Members)
                                      .ThenInclude(cm => cm.User)
                                      .ToList();
        return View(classes);
    }

    public IActionResult GetSchedule(int classId)
    {
        var schedules = _context.Schedules
                                .Where(s => s.ClassId == classId)
                                .Include(s => s.Subject)
                                .Include(s => s.Room)
                                .ToList();
        return Json(schedules);
    }

    [HttpPost]
    public IActionResult MarkAttendance(int scheduleId, int studentId, AttendanceStatus status)
    {
        var attendance = new Attendance
        {
            ScheduleId = scheduleId,
            StudentId = studentId,
            Status = status,
            Date = DateTime.UtcNow
        };

        _context.Attendances.Add(attendance);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
