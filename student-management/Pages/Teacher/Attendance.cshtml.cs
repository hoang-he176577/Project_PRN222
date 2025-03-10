using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;


namespace StudentManagement.Pages.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class AttendanceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AttendanceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Class> Classes { get; set; } = new List<Class>();
        public List<User> Students { get; set; } = new List<User>();
        public int SelectedClassId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? classId)
        {
            int teacherId = int.Parse(User.FindFirst("TeacherId")?.Value ?? "0");

            Classes = await _context.Classes
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

            if (classId.HasValue)
            {
          
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int classId, List<int> presentStudentIds)
        {
          
            await _context.SaveChangesAsync();
            return RedirectToPage(new { classId });
        }
    }
}