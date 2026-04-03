using AliMertTosunAracSinavi.Data;
using AliMertTosunAracSinavi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AliMertTosunAracSinavi.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Auth/Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Email veya şifre hatalı!";
                return View();
            }

            // Session bilgisi ekle
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("FullName", user.FullName);
            HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0);

            // Admin ise CRUD sayfasına, normal kullanıcı ise form sayfasına yönlendir
            if (user.IsAdmin)
            {
                return RedirectToAction("Index", "Kiralama"); // CRUD sayfası
            }
            else
            {
                return RedirectToAction("Create", "Kiralama"); // Form sayfası
            }
        }
        // GET: /Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["Success"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}