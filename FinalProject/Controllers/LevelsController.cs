using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class LevelsController : Controller
    {
        private readonly DataBaseContext _context;

        public LevelsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Levels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Levels.ToListAsync());
        }

        // GET: Levels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Levels
                .FirstOrDefaultAsync(m => m.LevelID == id);
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // GET: Levels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Levels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelID,BackGroundImage,LevelObsticles")] Level level)
        {
            if (ModelState.IsValid)
            {
                _context.Add(level);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(level);
        }

        // GET: Levels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }
            return View(level);
        }

        // POST: Levels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelID,BackGroundImage,LevelObsticles")] Level level)
        {
            if (id != level.LevelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(level);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelExists(level.LevelID))
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
            return View(level);
        }

        // GET: Levels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Levels
                .FirstOrDefaultAsync(m => m.LevelID == id);
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var level = await _context.Levels.FindAsync(id);
            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.LevelID == id);
        }
    }
}
