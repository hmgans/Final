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
 *    Home Controller
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Player")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Player")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Player")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
