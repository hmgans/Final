﻿/**
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
 *    Controller for Users, including purchases
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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(DataBaseContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            //_userContext = userContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        //Displays the view for the leaderboard
        public async Task<IActionResult> LeaderBoard()
        {
            var level_1 = _context.HighScores.Where(o => o.LevelID == 1).OrderBy(o => o.time).Take(10);
            var level_2 = _context.HighScores.Where(o => o.LevelID == 2).OrderBy(o => o.time).Take(10);
            var level_3 = _context.HighScores.Where(o => o.LevelID == 3).OrderBy(o => o.time).Take(10);
            var level_4 = _context.HighScores.Where(o => o.LevelID == 4).OrderBy(o => o.time).Take(10);
            var level_5 = _context.HighScores.Where(o => o.LevelID == 5).OrderBy(o => o.time).Take(10);

            ViewData["Level_1"] = level_1;
            ViewData["Level_2"] = level_2;
            ViewData["Level_3"] = level_3;
            ViewData["Level_4"] = level_4;
            ViewData["Level_5"] = level_5;




            return View(await _context.Users.ToListAsync());
        }

        //displays the view for the shop
        public async Task<IActionResult> Shop()
        {
            //gets the current user data and sends it to the view
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var email = _userManager.FindByIdAsync(userId).Result;

            var userInfo = _context.Users.Where(u => u.Email == email.Email).FirstOrDefault();



            ViewData["UserInfo"] = userInfo;

            return View();
        }

        //displays the view for the profile
        public async Task<IActionResult> Profile()
        {
            //gets the user information and passes it to the view
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var email = _userManager.FindByIdAsync(userId).Result;

            var userInfo = _context.Users.Where(u => u.Email == email.Email).FirstOrDefault();

            //gets the level times and passes it to the view
            var levelTimes = _context.HighScores.Where(u => u.UserID == userInfo.UserID).OrderBy(o => o.LevelID);

            ViewData["UserInfo"] = userInfo;

            ViewData["LevelTimes"] = levelTimes;

            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Email,Role,UserName,CurrentLevel,NosContainers,Cash,Nos,SkinRed,SkinBlue,SkinGreen,SkinPurple,SkinChrome")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Email,Role,UserName,CurrentLevel,NosContainers,Cash,Nos,SkinRed,SkinBlue,SkinGreen,SkinPurple,SkinChrome")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        //handles buying nos fromt eh shop
        [HttpPost]
        public JsonResult BuyNos(string Email, int Money)
        {
            //if the user has enough money, make the purchase

            if (Money >= 100)
            {

                var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
                user.NosContainers += 1;
                user.Cash -= 100;
                _context.SaveChanges();



                return Json(new { success = true, money = false});
            }
            else
            {
                return Json(new { success = false, money = true });
            }
        }

        //handles buying hte blue skin from the shop
        [HttpPost]
        public JsonResult BuyBlueSkin(string Email, int Money)
        {
            //if the user has enough money, make the purchase
            if (Money >= 200)
            {

                var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
                user.SkinBlue = true;
                user.Cash -= 200;
                _context.SaveChanges();



                return Json(new { success = true, money = false });
            }
            else
            {
                return Json(new { success = false, money = true });
            }
        }

        //handles buying the green skin for the shop
        [HttpPost]
        public JsonResult BuyGreenSkin(string Email, int Money)
        {
            //if the user has enough money, make the purchase

            if (Money >= 200)
            {

                var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
                user.SkinGreen = true;
                user.Cash -= 200;
                _context.SaveChanges();



                return Json(new { success = true, money = false });
            }
            else
            {
                return Json(new { success = false, money = true });
            }
        }

        //handles the buying purple skin for the shop
        [HttpPost]
        public JsonResult BuyPurpleSkin(string Email, int Money)
        {
            //if the user has enough money, make the purchase
            if (Money >= 200)
            {

                var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
                user.SkinPurple = true;
                user.Cash -= 200;
                _context.SaveChanges();



                return Json(new { success = true, money = false });
            }
            else
            {
                return Json(new { success = false, money = true });
            }
        }

        //handles the buying chrome skin from the shop
        [HttpPost]
        public JsonResult BuyChromeSkin(string Email, int Money)
        {
            //if the user has enough money, make the purchase

            if (Money >= 500)
            {

                var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
                user.SkinChrome = true;
                user.Cash -= 500;
                _context.SaveChanges();



                return Json(new { success = true, money = false });
            }
            else
            {
                return Json(new { success = false, money = true });
            }
        }

        //Handles the buying points request for the shop
        [HttpPost]
        public JsonResult BuyPoints(string Email, int Money)
        {

            var user = _context.Users.Where(e => e.Email == Email).FirstOrDefault();
            user.Cash += 500;
            
            _context.SaveChanges();


            return Json(new { success = true });
        }
    }
}
