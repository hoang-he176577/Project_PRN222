using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace StudentManagement.Pages.Student
{
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

        public async Task<IActionResult> OnGetAsync()
        {
            Terms = await _context.Terms
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.TermName })
                .ToListAsync();

            SelectedTermId = Terms.Any() ? int.Parse(Terms.First().Value) : 0;

            await LoadSchedule(SelectedTermId);

            return Page();
        }
        public async Task<IActionResult> OnGetLoadScheduleAsync(int termId)
        {
            await LoadSchedule(termId);
            return Partial("_ScheduleTable", ScheduleList); 
        }

        private async Task LoadSchedule(int termId)
        {
            var studentId = 11;

            ScheduleList = await _context.Schedules
                .Where(s => s.Class.Students.Any(st => st.Id == studentId) && s.TermId == termId)
                .Include(s => s.Subject)
                .Include(s => s.Teacher)
                .Include(s => s.Room)
                .Select(s => new ScheduleViewModel
                {
                    Id = s.Id,
                    SubjectName = s.Subject.SubjectName,
                    TeacherName = s.Teacher.Name,
                    RoomName = s.Room.RoomName,
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
