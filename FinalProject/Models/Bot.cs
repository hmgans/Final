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
 *    Model for Ghosts
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Bot
    {
        [Key]
        public int BotID { get; set; }
        public int LevelID { get; set; } // Min time for easy access
        public String Recording { get; set; }
        public int time { get; set; }
    }
}
