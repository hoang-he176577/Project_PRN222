using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace StudentManagement.Pages.Auth 
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? Error { get; set; }

        public void OnGet()
        {
            // Hiển thị trang đăng nhập
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            if (user == null)
            {
                Error = "Sai tên đăng nhập hoặc mật khẩu!";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            return RedirectToPage("/Index"); 
        }
    }
}