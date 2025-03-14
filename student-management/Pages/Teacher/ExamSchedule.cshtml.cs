using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Pages.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class ExamScheduleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ExamScheduleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Term> Terms { get; set; } = new List<Term>();
        public List<Exam> ExamList { get; set; } = new List<Exam>();
        public int SelectedTermId { get; set; }
        public int UserId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            UserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            Terms = await _context.Exams
                .Where(e => e.TeacherId == UserId)
                .Select(e => e.Term)
                .Distinct()
                .ToListAsync();

            ExamList = await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.Class)
                .Include(e => e.Room)
                .Include(e => e.Term)
                .Include(e => e.Teacher)
                .Where(e => e.TeacherId == UserId)
                .ToListAsync();

            if (termId.HasValue)
            {
                SelectedTermId = termId.Value;
                ExamList = ExamList.Where(e => e.TermId == termId.Value).ToList();
            }

            return Page();
        }
    }
}
