using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

namespace StudentManagement.Pages.Student
{
    [Authorize(Roles = "Student")]
    public class AttendanceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AttendanceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AttendanceSummaryViewModel> AttendanceSummary { get; set; } = new List<AttendanceSummaryViewModel>();
        public List<SelectListItem> Terms { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public int SelectedTermId { get; set; }

        [BindProperty]
        public int SelectedSubjectId { get; set; }

        public int UserId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId, int? subjectId, string? status)
        {
            UserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            Terms = await _context.Attendances
                .Where(a => a.StudentId == UserId)
                .Select(a => a.Schedule.Term)
                .Distinct()
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
                .ToListAsync();

            Subjects = await _context.Attendances
                .Where(a => a.StudentId == UserId)
                .Select(a => a.Schedule.Subject)
                .Distinct()
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToListAsync();

            SelectedTermId = termId ?? (Terms.Any() ? int.Parse(Terms.First().Value) : 0);
            SelectedSubjectId = subjectId ?? (Subjects.Any() ? int.Parse(Subjects.First().Value) : 0);

            await LoadAttendance(SelectedTermId, SelectedSubjectId, status);

            return Page(); // Use return Page instead of redirect to avoid redirect loop
        }

        public async Task<IActionResult> OnGetLoadAttendanceAsync(int termId, int subjectId, string? status)
        {
            try
            {
                await LoadAttendance(termId, subjectId, status);
                return Partial("_AttendanceTable", AttendanceSummary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        private async Task LoadAttendance(int termId, int subjectId, string? status)
        {
            var query = _context.Attendances
                .Include(a => a.Schedule)
                .ThenInclude(s => s.Subject)
                .Include(a => a.Schedule.Term)
                .Where(a => a.StudentId == UserId);

            if (termId > 0)
            {
                query = query.Where(a => a.Schedule.TermId == termId);
            }

            if (subjectId > 0)
            {
                query = query.Where(a => a.Schedule.SubjectId == subjectId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.Status.ToString() == status);
            }

            AttendanceSummary = await query
                .GroupBy(a => new { a.Schedule.Subject.Name, a.Status })
                .Select(g => new AttendanceSummaryViewModel
                {
                    SubjectName = g.Key.Name,
                    Status = g.Key.Status.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();
        }
    }

    public class AttendanceSummaryViewModel
    {
        public string SubjectName { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
