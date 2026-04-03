using AliMertTosunAracSinavi.Data;
using AliMertTosunAracSinavi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AliMertTosunAracSinavi.Controllers
{
    public class FormController : Controller
    {
        private readonly AppDbContext _context;

        public FormController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Form()
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
                return RedirectToAction("Login", "Auth");

            return View();
        }

        [HttpPost]
        public IActionResult Form(Kiralama model)
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
                return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.Session.GetInt32("UserId")!.Value;
                _context.Kiralamalar.Add(model);
                _context.SaveChanges();
                ViewBag.Success = "Talebiniz başarıyla eklendi!";
            }

            return View();
        }
    }
}