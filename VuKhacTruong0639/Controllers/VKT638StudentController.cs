using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VuKhacTruong0639.Models;

namespace VuKhacTruong0639.Controllers
{
    public class VKT638StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VKT638StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VKT638Student
        public async Task<IActionResult> Index()
        {
              return _context.VKT638Student != null ? 
                          View(await _context.VKT638Student.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VKT638Student'  is null.");
        }

        // GET: VKT638Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VKT638Student == null)
            {
                return NotFound();
            }

            var vKT638Student = await _context.VKT638Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (vKT638Student == null)
            {
                return NotFound();
            }

            return View(vKT638Student);
        }

        // GET: VKT638Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VKT638Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,StudentAge")] VKT638Student vKT638Student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vKT638Student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vKT638Student);
        }

        // GET: VKT638Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VKT638Student == null)
            {
                return NotFound();
            }

            var vKT638Student = await _context.VKT638Student.FindAsync(id);
            if (vKT638Student == null)
            {
                return NotFound();
            }
            return View(vKT638Student);
        }

        // POST: VKT638Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,StudentAge")] VKT638Student vKT638Student)
        {
            if (id != vKT638Student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vKT638Student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VKT638StudentExists(vKT638Student.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vKT638Student);
        }

        // GET: VKT638Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VKT638Student == null)
            {
                return NotFound();
            }

            var vKT638Student = await _context.VKT638Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (vKT638Student == null)
            {
                return NotFound();
            }

            return View(vKT638Student);
        }

        // POST: VKT638Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VKT638Student == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VKT638Student'  is null.");
            }
            var vKT638Student = await _context.VKT638Student.FindAsync(id);
            if (vKT638Student != null)
            {
                _context.VKT638Student.Remove(vKT638Student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VKT638StudentExists(int id)
        {
          return (_context.VKT638Student?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
