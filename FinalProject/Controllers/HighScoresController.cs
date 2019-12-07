/**
 * Author:    Jonathon Smith and Giovanni Varuloa and Hank Gansert
 * Partner:   None
 * Date:      12/4/19
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Jonathon Smith - This work may not be copied for use in Academic Coursework.
 *
 * I, Jonathon Smith and Giovanni Varuloa and Hank Gansert, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Controller for HighScores CRUD
 */

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
    public class HighScoresController : Controller
    {
        private readonly DataBaseContext _context;

        public HighScoresController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: HighScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.HighScores.ToListAsync());
        }

        // GET: HighScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScores
                .FirstOrDefaultAsync(m => m.HighScore_ID == id);
            if (highScore == null)
            {
                return NotFound();
            }

            return View(highScore);
        }

        // GET: HighScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HighScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HighScore_ID,UserID,LevelID,time,recording")] HighScore highScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highScore);
        }

        // GET: HighScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScores.FindAsync(id);
            if (highScore == null)
            {
                return NotFound();
            }
            return View(highScore);
        }

        // POST: HighScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HighScore_ID,UserID,LevelID,time,recording")] HighScore highScore)
        {
            if (id != highScore.HighScore_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighScoreExists(highScore.HighScore_ID))
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
            return View(highScore);
        }

        // GET: HighScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScores
                .FirstOrDefaultAsync(m => m.HighScore_ID == id);
            if (highScore == null)
            {
                return NotFound();
            }

            return View(highScore);
        }

        // POST: HighScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highScore = await _context.HighScores.FindAsync(id);
            _context.HighScores.Remove(highScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighScoreExists(int id)
        {
            return _context.HighScores.Any(e => e.HighScore_ID == id);
        }
    }
}
