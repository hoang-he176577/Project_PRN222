using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;


namespace StudentManagement.Pages.Student
{
    [Authorize(Roles = "Student")]
    public class ScoreModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ScoreModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Term> Terms { get; set; } = new List<Term>();
        public List<ScoreViewModel> ScoreList { get; set; } = new List<ScoreViewModel>();

        [BindProperty(SupportsGet = true)]
        public int SelectedTermId { get; set; }
        public int StudentId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            StudentId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            Terms = await _context.Scores
                .Where(s => s.StudentId == StudentId)
                .Select(s => s.Term)
                .Distinct()
                .ToListAsync();

            if (termId.HasValue)
            {
                SelectedTermId = termId.Value;
                await LoadScores(termId.Value);
            }
            else if (Terms.Any())
            {
                SelectedTermId = Terms.First().Id;
                await LoadScores(SelectedTermId);
            }

            return Page();
        }

        private async Task LoadScores(int termId)
        {
            ScoreList = await _context.Scores
                .Where(s => s.TermId == termId && s.StudentId == StudentId)
                .Select(s => new ScoreViewModel
                {
                    StudentName = s.Student.Name,
                    ScoreValue = s.Value,
                    TermName = s.Term.Name,
                    SubjectName = s.Subject.Name
                })
                .ToListAsync();
        }
    }

    public class ScoreViewModel
    {
        public string StudentName { get; set; } = string.Empty;
        public decimal ScoreValue { get; set; }
        public string TermName { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;

    }
}
