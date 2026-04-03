using AliMertTosunAracSinavi.Data;
using AliMertTosunAracSinavi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AliMertTosunAracSinavi.Controllers
{
    public class KiralamaController : Controller
    {
        private readonly AppDbContext _context;

        public KiralamaController(AppDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var kiralamalar = _context.Kiralamalar
                                       .Include(k => k.User)
                                       .ToList();
            return View(kiralamalar);
        }

        // Create (Kullanıcı için form doldurma)
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kiralama kiralama)
        {
            if (ModelState.IsValid)
            {
                _context.Kiralamalar.Add(kiralama);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kiralama);
        }

        // Edit
        public IActionResult Edit(int id)
        {
            var kiralama = _context.Kiralamalar.Find(id);
            if (kiralama == null) return NotFound();
            return View(kiralama);
        }

        [HttpPost]
        public IActionResult Edit(Kiralama kiralama)
        {
            if (ModelState.IsValid)
            {
                _context.Kiralamalar.Update(kiralama);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kiralama);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var kiralama = _context.Kiralamalar.Find(id);
            if (kiralama == null) return NotFound();
            return View(kiralama);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var kiralama = _context.Kiralamalar.Find(id);
            if (kiralama != null)
            {
                _context.Kiralamalar.Remove(kiralama);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}