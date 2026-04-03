using AliMertTosunAracSinavi.Data;
using AliMertTosunAracSinavi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AliMertTosunAracSinavi.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction("Login", "Auth");

            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction("Login", "Auth");

            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                _context.Users.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction("Login", "Auth");

            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}