using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;


namespace StudentManagement.Pages.Student
{
    [Authorize(Roles = "Student")]
    public class ScheduleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ScheduleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ScheduleViewModel> ScheduleList { get; set; } = new List<ScheduleViewModel>();
        public List<SelectListItem> Terms { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public int SelectedTermId { get; set; }
        public int UserId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            UserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            Terms = await _context.Schedules
                .Where(s => s.Class.Members.Any(cm => cm.UserId == UserId))
                .Select(s => s.Term)
                .Distinct()
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
                .ToListAsync();

            if (termId.HasValue)
            {
                SelectedTermId = termId.Value;
                await LoadSchedule(termId.Value);
            }
            else if (Terms.Any())
            {
                SelectedTermId = int.Parse(Terms.First().Value);
                await LoadSchedule(SelectedTermId);
            }

            return Page();
        }



        private async Task LoadSchedule(int termId)
        {
            ScheduleList = await _context.Schedules
                .Where(s => s.TermId == termId && s.Class.Members.Any(cm => cm.UserId == UserId))
                .Select(s => new ScheduleViewModel
                {
                    Id = s.Id,
                    SubjectName = s.Subject.Name,
                    TeacherName = s.Teacher.Name,
                    RoomName = s.Room.Name,
                    DaysOfWeek = s.DaysOfWeek,
                    StudySessions = s.StudySessions
                })
                .ToListAsync();
        }
    }

    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string RoomName { get; set; }
        public string DaysOfWeek { get; set; }
        public string StudySessions { get; set; }
    }
}