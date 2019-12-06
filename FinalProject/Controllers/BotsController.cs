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
    public class BotsController : Controller
    {
        private readonly DataBaseContext _context;

        public BotsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Bots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bots.ToListAsync());
        }

        // GET: Bots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots
                .FirstOrDefaultAsync(m => m.BotID == id);
            if (bot == null)
            {
                return NotFound();
            }

            return View(bot);
        }

        // GET: Bots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BotID,LevelID,Recording,time")] Bot bot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bot);
        }

        // GET: Bots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots.FindAsync(id);
            if (bot == null)
            {
                return NotFound();
            }
            return View(bot);
        }

        // POST: Bots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BotID,LevelID,Recording,time")] Bot bot)
        {
            if (id != bot.BotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotExists(bot.BotID))
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
            return View(bot);
        }

        // GET: Bots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots
                .FirstOrDefaultAsync(m => m.BotID == id);
            if (bot == null)
            {
                return NotFound();
            }

            return View(bot);
        }

        // POST: Bots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bot = await _context.Bots.FindAsync(id);
            _context.Bots.Remove(bot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotExists(int id)
        {
            return _context.Bots.Any(e => e.BotID == id);
        }
    }
}
