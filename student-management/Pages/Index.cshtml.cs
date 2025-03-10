
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace StudentManagement.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Auth/Login");
            }

            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return role switch
            {
                "Admin" => RedirectToPage("/Admin"),
                "Teacher" => RedirectToPage("/Teacher/Attendance"),
                "Student" => RedirectToPage("/Student/Attendance"),
                _ => RedirectToPage("/Auth/Login")
            };
        }
    }
}
